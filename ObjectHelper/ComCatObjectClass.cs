using CommonHelper;

namespace ObjectHelper
{
    public class ComCatObjectClass : EntityBase
    {

        private string fieldCategory, category, company, commonId, fieldcompany, bankname, branchname, companyname, itemplace, status;
        private int remove, categoryID, companyID, itemplaceid,bankid,branchid;

        public string FieldCategory
        {
            get { return fieldCategory; }
            set { fieldCategory = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public int Remove
        {
            get { return remove; }
            set { remove = value; }
        }
        public string CommonId
        {
            get { return commonId; }
            set { commonId = value; }
        }
        public string CategoryStatus
        {
            get { return status; }
            set { status = value; }
        }
        public string FieldCompany
        {
            get { return fieldcompany; }
            set { fieldcompany = value; }
        }
        public string ItemPlace
        {
            get { return itemplace; }
            set { itemplace = value; }
        }
        public int  BankID
        {
            get { return bankid; }
            set { bankid = value; }
        }
        public int BranchID
        {
            get { return branchid; }
            set { branchid = value; }
        }
        public int ItemPlaceID
        {
            get { return itemplaceid; }
            set { itemplaceid = value; }
        }
        public string BankName
        {
            get { return bankname; }
            set { bankname = value; }
        }
        public string BranchName
        {
            get { return branchname; }
            set { branchname = value; }
        }
        public string CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }
        public int GeneralTypeID { get; set; }
        public string UnitName { get; set; }
        public string UnitQuantity { get; set; }
        public Category ItemObj { get; set; }
        public string  FocusedControlName { get; set; }
        public string Printer { get; set; }
        
    }
}
