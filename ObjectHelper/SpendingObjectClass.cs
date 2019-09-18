using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class SpendingObjectClass
    {

        #region Constructor
        public SpendingObjectClass() { }
        public SpendingObjectClass(Int16 tableID) { TableID = tableID; }
        #endregion

        #region Properties
        public  Int16 TableID { get; set; }
        private string _det;
        public long ExpensesID { get; set; }
        public string Description { get; set; }
        public string Details
        {
            get { return _det; }
            set { _det = value; }
        }
        public string Notes { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ProcessDate { get; set; }
        public Int16 Status { get; set; }
        public Int16 Remove { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public long MinValue { get; set; }
        public int Year { get; set; }
        public long YearSequence { get; set; }
        public string NewYearNo { get; set; }
        public string ValidationString { get; set; }
        #endregion
    }
}
