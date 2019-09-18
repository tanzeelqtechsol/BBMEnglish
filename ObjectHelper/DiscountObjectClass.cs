using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace ObjectHelper
{
    public class DiscountObjectClass : EntityBase
    {

        private string _discountName, _discountId;
        private int _companyID, _categoryID, _discountFor;
        private decimal _discount;
        private DateTime? _startDate, _endDate, _createdDate, _modifiedDate;
        private Boolean _active;

        public string DiscountName
        {
            get { return _discountName; }
            set { _discountName = value; }
        }
        public string Discount1 { get; set; }
        public string Discount3 { get; set; }
        public string Discount2 { get; set; }
        public DateTime? StartDate1 { get; set; }
        public DateTime? StartDate2 { get; set; }
        public DateTime? StartDate3 { get; set; }
        public DateTime? EndDate1 { get; set; }
        public DateTime? EndDate2 { get; set; }
        public DateTime? EndDate3 { get; set; }
        public string DiscountID
        {
            get { return _discountId; }
            set { _discountId = value; }
        }
        public int DiscountFor
        {
            get { return _discountFor; }
            set { _discountFor = value; }
        }
        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public decimal Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public bool Active1 { get; set; }
        public bool Active2 { get; set; }
        public bool Active3 { get; set; }
        public decimal TotalAmtAftDiscount { get; set; }
        public decimal TotalAmtBfDiscount { get; set; }
        public decimal Profit { get; set; }

        public bool HasIncrease { get; set; }
        public int IncreaseType { get; set; }
    }
}
