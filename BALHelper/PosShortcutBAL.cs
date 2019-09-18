using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;

namespace BALHelper
{
    public class PosShortcutBAL
    {

        #region Declaration
        PosDalClass objPOSDalClass;
        POSObject objPOSObjectClass;
        #endregion

        #region Constructor
        public PosShortcutBAL()
        {
            objPOSDalClass = new PosDalClass();
            objPOSObjectClass = new POSObject();
        }
        #endregion

        #region Getting Pos Object Class in BAL Class
        public POSObject objPOSObject
        {
            get { return objPOSObjectClass; }
            set { objPOSObjectClass = value; }
        }
        #endregion

        #region Methods

        #region LoadItemDetailsBal
        public List<ItemCardObjectClass> LoadItemDetailsBal()
        {
            List<ItemCardObjectClass> ObjListItem = GeneralObjectClass.ItemDetails;

            var ObjListItemOne = (from p in ObjListItem
                                  where p.ItemType == 1 //"Goods"
                                  orderby p.Items
                                  select p).ToList();

            var ObjListItemTwo = (from p in ObjListItem
                                  where p.ItemType == 4 //"Meal"
                                  orderby p.Items
                                  select p).ToList();


            var ObjListItemThree = ObjListItemOne.Union(ObjListItemTwo);

            ObjListItemThree = ObjListItemThree.GroupBy(x => x.ItemId).Select(y => y.First());
            return ObjListItemThree.Distinct().ToList();
            //return ObjListItemThree.ToList();
        }

        public DataTable GetItemsForPOS()
        {
            return StoredProcedurers.GetPOSShortCutItem();
        }
        #endregion

        #region SaveButtonDetailsBal

        public bool SaveButtonDetailsBal()
        {

            return objPOSDalClass.SaveButtonDetails(objPOSObjectClass);

        }

        #endregion

        #region SaveTableDetailsBal

        public bool SaveTableDetailsBal()
        {

            return objPOSDalClass.SaveTableDetails(objPOSObjectClass);

        }

        #endregion

        #region GetButtonDetailsBal
        public List<POSObject> GetButtonDetailsBal()
        {
            return objPOSDalClass.GetButtonDetails(objPOSObjectClass);
        }
        #endregion

        #region GetTableDetailsBal
        public List<POSObject> GetTableDetailsBal()
        {
            return objPOSDalClass.GetTableDetails();
        }
        #endregion

        #region DeleteButtonDetailsBal
        public bool DeleteButtonDetailsBal()
        {

            return objPOSDalClass.DeleteButtonDetails(objPOSObjectClass);

        }

        #endregion

        #region DeleteTableDetailsBal
        public bool DeleteTableDetailsBal()
        {

            return objPOSDalClass.DeleteTableDetails(objPOSObjectClass);

        }

        #endregion

        #endregion


    }
}
