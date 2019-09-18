using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
//Created By Saradhaa.G
//Commonly used for Bank Deposit ,Bank With Draw ,CashCapital
namespace ObjectHelper
{
    public class BankObjectClass : EntityBase
    {
        public BankObjectClass() { }

        public BankObjectClass(int TransactionFlagType, short TableIDValue)
        {
            TransactionFlag = TransactionFlagType;
            TableID = TableIDValue;
        }
        public Int16 TableID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy  { get; set; }

        public long BankDetailID { get; set; }

        public long ReceiptNo { get; set; }
        public long DepositReceiptNo { get; set; }

        public long YearSequenceNo { get; set; }

        public int Year { get; set; }
       // public int WithDrawYear { get; set; }


        public int NewYearNo { get; set; }

        public string Description { get; set; }


        public string DepositDoneBy { get; set; }


        public string Reason { get; set; }

        public int BankNameID { get; set; }

        public string BankName { get; set; }
        public string BranchName { get; set; }

        public int BranchNameID { get; set; }

        public int BankToMoveID { get; set; }

        public int BranchToMoveID { get; set; }
        public int TransactionFlag { get; set; }


        public Int16 Status { get; set; }


        public string Notes { get; set; }



        public DateTime ProcessDate { get; set; }
        public int TransactionType { get; set; }



        public decimal Amount
        { get; set; }
        public decimal BalanceAmount { get; set; }

        public int ReasonId
        { get; set; }


        public int Remove
        { get; set; }


        public long MinId { get; set; }
        public long MaxId { get; set; }

        public string ValidationcontrolName { get; set; }

    }


}
