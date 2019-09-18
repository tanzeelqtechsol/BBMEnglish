using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using System.Threading;
using System.Globalization;
using System.Configuration;
using CommonHelper;
using System.Diagnostics;

namespace BumedianBM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GeneralFunction.Language = System.Configuration.ConfigurationManager.AppSettings["Language"];

            string encrpt = GeneralFunction.Decrypt("a8duxKmPE/GTre86C5luMUFS5jZoSg1gTvInRoiL3XU=");

            //   Process[] prs = Process.GetProcessesByName("BumedianBM");
            //if ((ConfigurationSettings.AppSettings["Restart"].ToString() == "True"))
            //{
            //  GeneralFunction.InfoMsg("Prgm  Start", "BM");
            GeneralFunction.SetConfigValue("Restart", "False");

            //**This is changed for the purpose of supporting all arabic countries date format. Done By A.Manoj On June-25-2014
            //HijriCalendar hijri = new HijriCalendar();
            GregorianCalendar grg = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
            if (ConfigurationSettings.AppSettings["Language"] == "Arabic")
            {
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-SA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-SA");
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                //culture.DateTimeFormat.Calendar = hijri;
                culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                culture.DateTimeFormat.LongTimePattern = "";
                culture.DateTimeFormat.Calendar = new System.Globalization.GregorianCalendar();
                Thread.CurrentThread.CurrentCulture = culture;

         
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.DateTimeFormat.Calendar = grg;
                culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                culture.DateTimeFormat.LongTimePattern = "";
                Thread.CurrentThread.CurrentCulture = culture;
            }
            //***********
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //this code add by thamil on 13_july_2915 for application not responding after long time.
            Application.DoEvents();
            Application.Run(new BumedianBM.ArabicView.MasterFrom());
        }
    }
}