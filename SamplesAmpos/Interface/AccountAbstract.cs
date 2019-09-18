using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.ViewHelper;

namespace BumedianBM.Interface
{
    public abstract class AccountAbstract

    {
        public static IAccountView GetAccountForm(string HelperClassName)
        {
            IAccountView accountview = null;
            switch (HelperClassName)
            {
                case "BankDeposit":
                  //  accountview = new BankDepositHelperClass();
                    break;
                case "BankWithdraw":
                 //   accountview = new BankWithdrawHelperClass();
                    break;
               
            }
            return accountview;



        }

    }
}
