using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonHelper
{
    public static class Constants
    {
        public const int _FontSize = 5;

        /// <summary>
        /// Common Messages for All Forms
        /// </summary>
        public const string NUMERSONLYMESSAGE = "You Can Only Enter the Numeric Values.";
        public const string CLOSE = "Do You Want To Close";
        public const string CONFIRM_DELETE = "Do You Want To Delete";
        public const string RECORDNOTFOUND = "There is no Record";
        public const string UPDATEQUESTION = "Do You Want to Update the Details";
        public const string INVALIDOPERATION = "Invalid Operation";
        // public const string ITEMEXIST = "Item Does not Exist";

        public const string DELETE = "Item Deleted Successfully";
        public const string ITEMUNDERINVOICE = "Item can not be deleted";
        public const string INVAILDTODELETE = " Select a item to be deleted";
        public const string SAVE = "Details are Saved Successfully";
        public const string UPDATE = "Details are Updated Successfully";
        public const string REQUIRED = "Should not be Empty";
        public const string CANCEL = "Do You Want to Clear";
        public const string DETAILDELETE = "Details deleted Successfully";
        public const string NOT_DELETED = "Details not deleted";
        public const string NOT_SAVED = "Details not saved";

        /// <summary>
        /// ItemCard Message
        /// </summary>

        public const string ITEMNAME = "Item Names is Required";
        public const string ITEMNO = "Item name Already Exist";
        public const string ITEMTYPEID = "Item type Is Required";
        public const string ITEMSAVE = "Item  are saved successfully";
        public const string ITEMBARCODE = "Barcode should not be empty";
        public const string ITEMBARCODE_DUP = "The barcode already exists please generate new barcode";
        public const string ITEMBARCODE_GEN = "Barcode automatically generated for this item";
        //public const string ITEMUPDATE = "Item details are updated";
        public const string ALTERFOREXPIRY = "Do you want to Enable the Expiry";
        public const string REMOVEALTERFOREXPIRY = "Do you want to Disable the Expiry";
        public const string BARCODE = "BarCode is already Exsit";
        public const string AdditionalBarcode = "Additional barcode cannot added for new item";

        public const string CategorySave = "Category detail saved";
        public const string CategoryAlreadyExits = "Category name is already exits";
        /// <summary>
        /// Agent Details
        /// </summary>
        public const string AGENTNAMEREQUIRED = "Agent Name is Required";
        public const string AGENTDELETED = "Agent Details are Deleted";
        public const string AGENTREQUIRED = "Agent Type is Required";
        public const string AGENTUPDATE = "Agent details are Updated";
        public const string AGENTNAMEEXIST = "Agent Name is already Exist";
        public const string AGENTSAVE = "Agent details are saved";

        public const string NORIGHTSTOOPENTAB = "No rights to open this tab";
        

        #region Employee Drawings
        public const string EMPLOYEEDETAILSSAVED = "Employee details are saved";
        public const string USERNAMEREQUIRED = "User Name is Required";
        public const string AMOUNTREQUIRED = "Amount is Required";
        public const string DESCRIPTIONREQUIRED = "Description is Required";
        public const string AMOUNTCUTOPTIONREQUIRED = "Amount cut monthly is Required";
        public const string EMPLOYEEDETAILSNOTSAVED = "Employee details not saved";
        public const string GenerateItemBarcodes = "Barcode generated successfully for all items";
        #endregion

        #region Employee Variables

        public const string GROUPNAMEREQUIRED = "Group Name is Required";
        public const string CHECKANYONEGROUP = "Please check any one of the group";
        public const string VARIABLEREQUIRED = "Variable is Required";
        public const string CHECKAMOUNTCUTOPTION = "Please check any one of monthly cut option";
        public const string NOUSERGROPDEFAULTVALUES = "No default values for this user group";
        public const string NORIGHTSTOCHANGEADMINPRIVILEGES = "No rights to change admin privileges";
        
        #endregion

        #region Employee Details
        public const string INVALIDDATE = "Please select valid date";
        public const string CHECKANYONEGROUPTYPE = "Please check any one of the user group";
        public const string GROUPNAMEEMPLOYEENAMEREQUIRED = "Group name or Employee name is Required";
        public const string EMPLOYEENAMEREQUIRED = "Employee name is Required";
        public const string USERGROUPEXISTS = "Usergroup already exist";
        public const string PASSWORDMISMATCH = "Password and Confirm password mismatched";
        public const string USERGROUPREQUIRED = "User group is Required";
        public const string HOURLYEMPLOYEECREATEUSERACCOUNT = "you are a hourly employee. You must create a user account";
        public const string USERNAMEEXISTS = "User Name already exist";
        public const string DELETEUSER = "User details deleted successfully";
        public const string EMPLOYEESNOTDELETED = "User details not deleted";
        public const string EMPLOYEEINVOLVEDINVOICE = "Sorry unable to delete due to user involved in invoice";
        
        
        
        #endregion

        #region Employee Notes
        public const string CHECKANYONEVARIABLE = "Please check any one of the variables";
        public const string NOOFTIMEREQUIRED = "No of time is required";
        public const string MESSAGEREQUIRED = "Notes is required";
        public const string SETVALIDDATE = "Date should be today or greater than today";
        

        
        #endregion

        #region
        public const string EMPTYSTARTTIME = "Start time should not be empty";
        #endregion

        #region Account
        public const string INVALIDWITHDRAW = "Withdraw amount should not be greater than amount in bank";
        #endregion

        #region SalaryPayment
        public const string SelectPayEmployeeOf = "Select the Pay Employee Of";
        public const string FromDateLessthanTodate = "FromDate should be less than ToDate";
        
        
        #endregion







        public const   string CompanySave ="Company Details Saved";
        public const string CompanyExits = "Company name is already exits";

        public const string BankSave = "Bank Name Saved";

        public const  string BankAlreadyExits = "Bank Name alreay exit";

        public const  string BranchSave = "Branch Details Saved";

        public const string BranchAlreadyExits = "Branch name Already exit";

        public const string ItemPlaceSave = "Item Details Saved";

        public const string ItemPlaceAlreadyExits = "ItemPlace name Already exit";

        public const string CategoryNameisRequired = "Category Name is Required";

        public const string CompanyNameIsRequired = " Company Name Is Required";

        public const string ItemPlace = "Itemplace Name is Required";

        public const string Bank = "Bank Name is Required";

        public const string Branch = "Branch Name is Required";
        public const string ReturnOrderItem = "Items are return successfully";
    }
}
