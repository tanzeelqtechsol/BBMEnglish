using BALHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BumedianBM.ViewHelper
{
    public class UserFavoriteQueryHelper
    {
        UserFavoriteQueryBALClass objbalclass;
        public UserFavoriteQueryHelper()
        {
            objbalclass = new UserFavoriteQueryBALClass();
        }
        public UserFavoriteQueryBALClass ObjBALClass
        {
            get { return objbalclass; }
            set { objbalclass = value; }
        }

    }
}
