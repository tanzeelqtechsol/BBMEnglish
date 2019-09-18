using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using System.IO;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using CommonHelper;

namespace BumedianBM.ViewHelper
{
    class OptionSettingHelper
    {
        OptionSettingBAL objOptionSettingBALClass;
        public List<OptionSettingsObject> lstOptions;
        public List<OptionSettingsObject> lstLogo;

        public OptionSettingHelper()
        {
            objOptionSettingBALClass = new OptionSettingBAL();
        }
        public OptionSettingBAL objOptionSettingsBAl
        {
            get { return objOptionSettingBALClass; }
            set { objOptionSettingBALClass = value; }
        }

        public void LoadOptions()
        {
            lstOptions = objOptionSettingBALClass.LoadOptions();
        }

        public int UpdateLastBackupDate()
        {
            //int value = objOptionSettingBALClass.UpdateLastBackupDate();
            //return value;
            return objOptionSettingBALClass.UpdateLastBackupDate();
        }
        public void UpdateLoginStatus()
        {
            objOptionSettingBALClass.UpdateLoginStatus();

        }
        public void LoadLogo()
        {
            lstLogo = objOptionSettingBALClass.LoadLogo();

        }

        public byte[] PathtoByte(string Path)
        {
            //FileStream fs;
            //BinaryReader br;
            byte[] logobyte;
            Bitmap bmp = null;

            try
            {
                if (Path != string.Empty)
                {
                    bmp = new Bitmap(Path);
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    logobyte = new byte[ms.Length];
                    logobyte = ms.ToArray();

                    //fs = new FileStream(Path , FileMode.Open, FileAccess.Read, FileShare.Read);
                    //br = new BinaryReader(fs);
                    //logobyte = new byte[fs.Length + 1];
                    //logobyte = br.ReadBytes(Convert.ToInt32(fs.Length));
                    //fs.Close();
                    //br.Close();
                }
                else
                {
                    logobyte = new byte[1];
                    logobyte[0] = 0;
                }
                return logobyte;
            }
            catch (Exception)
            {
                logobyte = new byte[1];
                logobyte[0] = 0;
                return logobyte;
            }
        }

        public int SaveOptionSettingDet()
        {
            //int value = objOptionSettingBALClass.SaveOptionSetting();
            //return value;
            return objOptionSettingBALClass.SaveOptionSetting();
        }

        public Boolean Update_CashClientNameDet()
        {
            //bool value = objOptionSettingBALClass.Update_CashClientName();
            //return value;
            return objOptionSettingBALClass.Update_CashClientName();
        }

        public Boolean LogOut_UserProc()
        {
            //bool value = objOptionSettingBALClass.LogOut_User();
            //return value;
            return objOptionSettingBALClass.LogOut_User();
        }

        public Boolean StartNewYearHelper()
        {
            objOptionSettingBALClass.objOptionSettingsObject.YearforStartNewYear = DateTime.Now.Year;
            //bool value = objOptionSettingBALClass.StartNewYear();
            //return value;
            return objOptionSettingBALClass.StartNewYear();
        }
        public Boolean SaveNotificationDatesHelper()
        {
            //bool value = objOptionSettingBALClass.SaveNotificationDatesBal();
            //return value;
            return objOptionSettingBALClass.SaveNotificationDatesBal();
        }

        public List<EmployeeObjectClass> AddDefaultDataHelper()
        {
            return objOptionSettingsBAl.AddDefaultData();
        }
        public Boolean CleanDB()
        {
            if (objOptionSettingsBAl.BALCleanDB())
                return true;
            else
                return false;
        }
        public Boolean AddedQuantities()
        {
            if (objOptionSettingsBAl.AddedQuantity())
                return true;
            else
                return false;
        }

    }
}
