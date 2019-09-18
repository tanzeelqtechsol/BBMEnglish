using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;

namespace BALHelper
{
    public class CleanDBInformationBAL
    {
        CleanDBInfoDAL objCleanDBInfoDAL;
        OptionSettingsObject objOptionSettingsObjectClass;

        public CleanDBInformationBAL()
        {
            objCleanDBInfoDAL = new CleanDBInfoDAL();
            objOptionSettingsObjectClass = new OptionSettingsObject();
        }

        public OptionSettingsObject objOptionSettingsObject
        {
            get { return objOptionSettingsObjectClass; }
            set { objOptionSettingsObjectClass = value; }
        }

        public int CleanDBBal()
        {
            if (objCleanDBInfoDAL.CleanDB(objOptionSettingsObjectClass) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


    }
}
