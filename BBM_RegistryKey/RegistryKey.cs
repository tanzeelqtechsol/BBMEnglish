using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Drawing;

namespace BBM_RegistryKey

{
    static class RegisterKey
    {
        static void Main()
        {
            RegistryKey regKey = Registry.LocalMachine;
            string RegEditPath=@"SOFTWARE\\Classes\\{BBECB0AB-6805-4103-BFB5-B7987D93B4B3}";
            string strDate = string.Format("{0}/{1}/{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
            if ((regKey.OpenSubKey(RegEditPath)) == null)
            {
                regKey.CreateSubKey(RegEditPath);
                regKey = regKey.OpenSubKey(RegEditPath, true);
                regKey.SetValue("DATE", strDate);
                regKey.SetValue("CDATE", strDate);
                regKey.SetValue("ISTRIAL", "YES");
                regKey.SetValue("COUNT", 1);
                regKey.SetValue("WORKSTATION", 0);
            }
            else if (regKey.GetValue("WORKSTATION") == null)
            {
                regKey.SetValue("WORKSTATION", 0);
            }
        }
    }
}
