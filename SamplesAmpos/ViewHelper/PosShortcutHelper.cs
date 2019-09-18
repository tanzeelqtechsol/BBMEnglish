using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.Interface;
using BALHelper;
using System.Data;
using ObjectHelper;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CommonHelper;
namespace BumedianBM.ViewHelper
{

    class PosShortcutHelper
    {

        #region Declaration
        PosShortcutBAL objPosShortcutBal;
        public Bitmap Bmp;
        public MemoryStream Ms;
        public string ImagePath;
        public byte[] ButtonImage;
        public List<POSObject> lstButtonDetailsOne = new List<POSObject>();
        public List<POSObject> lstFilteredButtonDetail = new List<POSObject>();
        public List<POSObject> lstTableDetails = new List<POSObject>();
        public List<POSObject> lstFilteredTableDetail = new List<POSObject>();
        public int TabIndex;
        #endregion

        #region Constructor
        public PosShortcutHelper()
        {
            objPosShortcutBal = new PosShortcutBAL();
        }
        #endregion

        #region Getting POS BAL Class in Helper
        public PosShortcutBAL objPOSShortCutBal
        {
            get { return objPosShortcutBal; }
            set { objPosShortcutBal = value; }
        }

        #endregion

        #region UIDatabaseMethods

        #region LoadItemDetails
        public List<ItemCardObjectClass> LoadItemDetails()
        {
            //List<ItemCardObjectClass> ObjListAgent = objPosShortcutBal.LoadItemDetailsBal();
            //return ObjListAgent;

            return objPosShortcutBal.LoadItemDetailsBal();
        }
        public DataTable GetItem()
        {
            DataTable filter= objPosShortcutBal.GetItemsForPOS();
            if (GeneralOptionSetting.FlagShowHidenItem == "N")
            {
                DataView dataview = new DataView(filter);
                dataview.RowFilter = "IsHide='" + 0 + "'";
                return dataview.ToTable();
            }
            else
            {
                //dataview.RowFilter = "IsHide='" + 0 + "' OR IsHide='" + 1 + "'";
                //return dataview.ToTable();
                return filter;
            }
        }
        #endregion

        #region SaveButtonDetailsHelper
        public bool SaveButtonDetailsHelper()
        {

            return objPosShortcutBal.SaveButtonDetailsBal();

        }
        #endregion

        #region SaveTableDetailsHelper
        public bool SaveTableDetailsHelper()
        {

            return objPosShortcutBal.SaveTableDetailsBal();

        }
        #endregion

        #region GetButtonDetailsHelper
        public void GetButtonDetailsHelper()
        {
            lstButtonDetailsOne = objPosShortcutBal.GetButtonDetailsBal();
        }
        #endregion

        #region GetTableDetailsHelper
        public void GetTableDetailsHelper()
        {
            lstTableDetails = objPosShortcutBal.GetTableDetailsBal();
        }
        #endregion

        #region DeleteButtonDetailsHelper
        public bool DeleteButtonDetailsHelper()
        {

            return objPosShortcutBal.DeleteButtonDetailsBal();

        }

        #endregion

        #region DeleteTableDetailsHelper
        public bool DeleteTableDetailsHelper()
        {

            return objPosShortcutBal.DeleteTableDetailsBal();

        }

        #endregion

        #endregion

        #region UIHelperMethods

        #region BrowseImage
        public void BrowseImage()
        {

            if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex == -1) return;
            Bitmap bmp;
            Ms = new MemoryStream();
            OpenFileDialog Objfd = new OpenFileDialog();
            Objfd.Title = "Open Image Files";
            Objfd.Filter = "Image Files(JPEG,BMP,ICO,PNG,GIF)|*.jpg;*.bmp;*.ico;*.png;*.gif";
            //Objfd.Filter = "JPEG|*.jpg|BMP|*.bmp|ICO|*.ico|PNG|*.png";
            if (Objfd.ShowDialog() == DialogResult.OK)
            {
                Bmp = new Bitmap(Objfd.FileName);
                //  Pic_Img.Image = bmp;
                //  Pic_Img.Image.Save(ms, Pic_Img.Image.RawFormat);
                //bmp.Save(ms, bmp.RawFormat);
                ButtonImage = new byte[Ms.Length];
                ButtonImage = Ms.GetBuffer();
                ImagePath = Objfd.FileName;

            }
            else ImagePath = Objfd.FileName;

        }
        #endregion

        #region ValidationOnSave
        public bool ValidationOnSave()
        {
            try
            {
                if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex == -1 && objPosShortcutBal.objPOSObject.AdditionShorcutSelectedIndex == -1)
                { GeneralFunction.Information("Select the ShortCut", "POSShortcuts"); return false; }
                else if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex != -1 && objPosShortcutBal.objPOSObject.ItemSelectedIndex == -1)
                { GeneralFunction.Information("Select the Item", "POSShortcuts"); return false; }
                else if (objPosShortcutBal.objPOSObject.AdditionShorcutSelectedIndex != -1 && objPosShortcutBal.objPOSObject.AdditionDescText == string.Empty)
                { GeneralFunction.Information("Enter the addition description", "POSShortcuts"); return false; }
                else return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region ValidationOnSaveTable
        public bool ValidationOnSaveTable()
        {
            try
            {
                if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex == -1)
                { GeneralFunction.Information("Select the ShortCut", "TableShortcuts"); return false; }
                else if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex != -1 && objPosShortcutBal.objPOSObject.Discription == string.Empty)
                { GeneralFunction.Information("Enter the description", "TableShortcuts"); return false; }
                else return true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region FilterButtonList
        public void FilterButtonList()
        {
            lstFilteredButtonDetail = lstButtonDetailsOne;
            lstFilteredButtonDetail = (from p in lstFilteredButtonDetail
                                       where p.ShortCut == objPosShortcutBal.objPOSObject.ShortCut && p.AdditionFlag == objPosShortcutBal.objPOSObject.AdditionFlag
                                       select p).ToList();

        }
        #endregion

        #region FilterTableList
        public void FilterTableList()
        {
            lstFilteredTableDetail = lstTableDetails;
            lstFilteredTableDetail = (from p in lstFilteredTableDetail
                                       where p.ShortCut == objPosShortcutBal.objPOSObject.ShortCutText 
                                       select p).ToList();

        }
        #endregion

        #region AddImage
        public void AddImage(string flag, ImageList imgListButtons)
        {

            try
            {
                if (flag == "N")
                {
                    imgListButtons.Images.Clear();
                    for (int i = 0; i < lstButtonDetailsOne.Count; i++)
                    {
                        byte[] imgbyte = lstButtonDetailsOne[i].ImageByte.GetType() != typeof(System.DBNull) ? (byte[])lstButtonDetailsOne[i].ImageByte : new byte[0];
                        if (imgbyte.Length > 1)
                        {
                            MemoryStream ms = new MemoryStream(imgbyte, true);
                            Bitmap bmp = (Bitmap)Image.FromStream(ms);
                            imgListButtons.Images.Add(bmp);
                        }

                    }
                }
                else
                {
                    // ImgLst_Button.Images.Clear();
                    byte[] imgbyte = lstFilteredButtonDetail[0].ImageByte.GetType() != typeof(System.DBNull) ? (byte[])lstFilteredButtonDetail[0].ImageByte : new byte[0];
                    if (imgbyte.Length > 1)
                    {
                        MemoryStream ms = new MemoryStream(imgbyte, true);
                        Bitmap bmp = (Bitmap)Image.FromStream(ms);
                        imgListButtons.Images.Add(bmp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DeleteButton
        public bool DeleteButton()
        {
            bool result = false;

            if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex == -1 && objPosShortcutBal.objPOSObject.AdditionShorcutSelectedIndex == -1)
            {
                GeneralFunction.Information("Select the ShortCut to delete", "POSShortcuts");
                result = false;

            }
            else if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex != -1)
            {
                objPosShortcutBal.objPOSObject.ShortCut = objPosShortcutBal.objPOSObject.ShortCutText;
                objPosShortcutBal.objPOSObject.AdditionFlag = 0;
                if (DeleteButtonDetailsHelper())
                {
                    GeneralFunction.Information("Button details deleted successfully", "POSShortcuts");
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Delete), "button detail", "ButtonSelection", "Delete POS shortcut button details", Convert.ToInt16(InvoiceAction.No));
                    result = true;
                }

            }

            else
            {
                objPosShortcutBal.objPOSObject.ShortCut = objPosShortcutBal.objPOSObject.AdditionShortCutText;
                objPosShortcutBal.objPOSObject.AdditionFlag = 1;
                if (DeleteButtonDetailsHelper())
                {
                    GeneralFunction.Information("Addition Button details deleted successfully", "POSShortcuts");
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Delete), "button detail", "ButtonSelection", "Delete POS shortcut button details", Convert.ToInt16(InvoiceAction.No));
                    result = true;
                }
            }



            return result;
        }
        #endregion


        #region DeleteTable
        public bool DeleteTable()
        {
            bool result = false;

            if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex == -1 )
            {
                GeneralFunction.Information("Select the ShortCut to delete", "TableShortcuts");
                result = false;

            }
            else if (objPosShortcutBal.objPOSObject.ShorcutSelectedIndex != -1)
            {
                objPosShortcutBal.objPOSObject.ShortCut = objPosShortcutBal.objPOSObject.ShortCutText;
                if (DeleteTableDetailsHelper())
                {
                    GeneralFunction.Information("Button details deleted successfully", "TableShortcuts");
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Delete), "table detail", "TableSelection", "Delete POS shortcut table button details", Convert.ToInt16(InvoiceAction.No));
                    result = true;
                }

            }

            return result;
        }
        #endregion


        #region DeleteButtondetails
        public void DeleteButtondetails(Control.ControlCollection ctr, string shortcut, string flag)
        {
            System.Windows.Forms.Button Btn;
            Control[] cn;
            string str;
            if (flag == "N")
            {
                str = "Btn" + shortcut;
                cn = ctr.Find(str, true);
                Btn = (Button)cn[0];
                Btn.Text = shortcut;
                Btn.ImageList = null;
            }
            else
            {
                str = "Btn_Add" + shortcut;
                cn = ctr.Find(str, true);
                Btn = (Button)cn[0];
                Btn.Text = shortcut;
                Btn.ImageList = null;
            }
        }
        #endregion


        #endregion

    }
}
