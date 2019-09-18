using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
using ObjectHelper;

namespace BumedianBM.ViewHelper
{
   public class TipOfDayHelper
    {
       public LoginObjectClass Objlogin;
       public string[] LoadTipOfDay()
       {
           GeneralFunction.GetOptionDatas();
           if (GeneralFunction.lstTips.Count <= 0)
           {
               GeneralFunction.LoadTips();
           }
           if (GeneralFunction.lstTips.Count >= 1)
           {
               Random rdmNumber = new Random();
               GeneralFunction.TipsCount = rdmNumber.Next(1, GeneralFunction.lstTips.Count);
           }
           string[] str = ShowTips();
          // ShowTips();
           return str;
       }

       public string[] ShowTips()
       {
           string tips=string.Empty;
           //Objlogin.chkShowTip = GeneralOptionSetting.FlagShowTipDayWhenStart != null && GeneralOptionSetting.FlagShowTipDayWhenStart == "Y" ? true : false;
           if (GeneralFunction.lstTips != null && GeneralFunction.TipsCount < GeneralFunction.lstTips.Count && GeneralFunction.TipsCount >= 0)
           {
               tips = "     " + GeneralFunction.lstTips[GeneralFunction.TipsCount];
           }
           else
           {
               tips = "     Welcome to BumendianBM";
           }
           string[] str = { "", "", "", tips };
          // Objlogin.Tips = str;
           return str;
       }
    }
}
