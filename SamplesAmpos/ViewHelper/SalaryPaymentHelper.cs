using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using BALHelper;
using CommonHelper;
using System.Data;
using System.ComponentModel;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
namespace BumedianBM.ViewHelper
{
    public class SalaryPaymentHelper
    {
        #region Variables
        Dictionary<string, List<EmployeeObjectClass>> dicSalHelper = new Dictionary<string, List<EmployeeObjectClass>>();
        List<EmployeeObjectClass> listSalHelper = new List<EmployeeObjectClass>();
        decimal FinalEmpWorkSal, FinalOvrtimeSal, FinalHolidaySal, FinalLaten;
        double PubOverTime = 0, PubHoliday = 0;
        decimal DrawAmt, varAmt, TotAmt, ADDTotAmt;
        public SalaryPaymentBAL ObjSalPayBALClass;
        decimal TBaseSalary = 0, TOverTime = 0, TAdvances = 0, TPunishment = 0, TReward = 0,
                 TIncentives = 0, TOthers = 0, TAmount = 0, TNetSalary = 0, TNeglet = 0;
        #endregion
        public SalaryPaymentHelper()
        {
            ObjSalPayBALClass = new SalaryPaymentBAL();
            ObjSalPayBALClass.SetCommonObject();
        }
        public SalaryPaymentBAL ObjSalPay
        {
            get { return ObjSalPayBALClass; }
            set { ObjSalPayBALClass = value; }
        }
        public List<EmployeeObjectClass> GetEmpSalaryDetails(int ViewType)
        {
            try
            {
                if (ValidationChecking() == true)
                {
                    dicSalHelper = ObjSalPay.GetSalaryDetails();
                    if (ViewType != -1)
                    {
                        switch (ViewType)
                        {
                            case 0:
                                listSalHelper = FillDatasInGridViewByMONTHLY(0);
                                break;
                            case 1:
                                listSalHelper = FillDatasInGridViewByMONTHLY(1);
                                break;
                            case 2:
                                listSalHelper = FillDatasInGridViewByHOURLY(2);
                                break;
                            case 3:
                                listSalHelper = FillDatasInGridViewByPERCENTAGE(3);
                                break;
                            case 4:
                                listSalHelper = FillDatasInGridViewByALL();
                                break;
                        }
                    }

                    // dicSaltHelper["EmpBasicdetails"];
                }
                return listSalHelper;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<EmployeeObjectClass> FillDatasInGridViewByALL()
        {
            listSalHelper.Clear();
            listSalHelper = FillDatasInGridViewByMONTHLY(0);     // Monthly
            listSalHelper = FillDatasInGridViewByMONTHLY(1);   // Weekly
            listSalHelper = FillDatasInGridViewByHOURLY(2);    // Hourly
            listSalHelper = FillDatasInGridViewByPERCENTAGE(3);   // Percentage
            CalculateTotal();
            return listSalHelper;
        }
        private Boolean ValidationChecking()
        {
            try
            {
                if (ObjSalPay.ObjEmployeeObject.chkAllEmployee != true)
                {
                    if (ObjSalPay.ObjEmployeeObject.cmbPayEmpOf == -1)
                    {
                        GeneralFunction.ErrInfo(Constants.SelectPayEmployeeOf, ActionType.View.ToString());
                        //Cmb_PayEmployee.Focus();
                        return false;
                    }

                    else
                    {
                        if (ObjSalPay.ObjEmployeeObject.FromDate > ObjSalPay.ObjEmployeeObject.ToDate)
                        {
                            GeneralFunction.ErrInfo(Constants.FromDateLessthanTodate, ActionType.View.ToString());
                            //  Dtp_FromDate.Focus();
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #region FillDatasInGridViewByMONTHLY
        public List<EmployeeObjectClass> FillDatasInGridViewByMONTHLY(int ViewType)
        {
            int EMPID;
            decimal baseSal = 0, OvrtimeSal = 0; decimal Avg = 0;
            string Otime = string.Empty; string HoliTime = string.Empty;
            int TotalDays = 0, EmpPresentDays = 0;
            if (ObjSalPay.ObjEmployeeObject.chkAllEmployee != true)
            {
                listSalHelper.Clear();
            }
            if (dicSalHelper != null)
            {
                var index = dicSalHelper["EmpBasicdetails"].FindAll(x => x.CalcType == ViewType);
                //Commented on 6-May-2014. If i value start from 20. when Count is less than 20 for loop will not execute. by Seenivasan
                //for (int i = 20; i < index.Count; i++)
                //{
                for (int i = 0; i < index.Count; i++)//Added on 6-May-2014
                {
                    int system = index[i].CalcType;

                    //-----------------------------------------
                    if (system == ViewType)
                    {
                        EMPID = index[i].UserId;
                        decimal Base = index[i].BasicSalary;
                        decimal OSal = index[i].OverTimeSal;
                        decimal HSal = index[i].HolidaySal;
                        baseSal = Convert.ToDecimal(Base);
                        OvrtimeSal = Convert.ToDecimal(OSal);
                        string hrsinday = index[i].EmpWorkHrs.ToString();
                        int CalHRS = 0;
                        if (hrsinday != "")
                        {
                            string[] ssss = hrsinday.Split(':');
                            CalHRS = Convert.ToInt32((Convert.ToInt32(ssss[0])) + (Convert.ToInt32(ssss[1]) * (0.16666666666666666666666666666667)));
                        }
                        int GetWeekend, MonthHolidays = 0;
                        if (dicSalHelper["EmpWeekOffDetails"] != null)
                        {
                            var WeekOffindex = dicSalHelper["EmpWeekOffDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
                            if (WeekOffindex.Count > 0)
                            {
                                GetWeekend = WeekOffindex[0].WeekEnd;
                                if (GetWeekend == 1)
                                    MonthHolidays = WeekOffindex[0].Suncount;
                                else if (GetWeekend == 2)
                                    MonthHolidays = WeekOffindex[0].Moncount;
                                else if (GetWeekend == 3)
                                    MonthHolidays = WeekOffindex[0].Tuescount;
                                else if (GetWeekend == 4)
                                    MonthHolidays = WeekOffindex[0].Wedcount;
                                else if (GetWeekend == 5)
                                    MonthHolidays = WeekOffindex[0].Thurscount;
                                else if (GetWeekend == 6)
                                    MonthHolidays = WeekOffindex[0].Fricount;
                                else
                                    MonthHolidays = WeekOffindex[0].Satcount;
                            }
                            else
                            {
                                GetWeekend = 0;
                                MonthHolidays = 0;
                            }
                        }
                        int ttday = 30;
                        int holiday = Convert.ToInt32(MonthHolidays);
                        int workingday = (ttday - holiday);
                        int worHRSperMon = (CalHRS * workingday);
                        decimal HRSRate = (baseSal / worHRSperMon);
                        decimal OneDayRate = (CalHRS * Convert.ToDecimal(HRSRate.ToString("########0.000")));
                        if (dicSalHelper["EmpSalDetails"] != null)
                        {
                            var Salindex = dicSalHelper["EmpSalDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
                            string TotalWorkedHRS = string.Empty;
                            if (Salindex.Count > 0)
                            {
                                TotalWorkedHRS = Salindex[0].WorkTimings;
                                TotalDays = Salindex[0].WorkingDays;
                                EmpPresentDays = Salindex[0].WorkedDays;
                            }
                            double hr = 0, mi = 0; decimal ttempHRS = 0;
                            decimal EmpWorkSal = 0;
                            int miHH = 0;
                            if (TotalWorkedHRS != "")
                            {
                                string[] hrsMin = TotalWorkedHRS.Split(':');
                                hr = Convert.ToInt32(hrsMin[0]);

                                if (Convert.ToInt32(hrsMin[1]) > 60)
                                {
                                    decimal vval = (Convert.ToDecimal(hrsMin[1]) / 60);
                                    string[] Minshh = vval.ToString().Split('.');
                                    miHH = Convert.ToInt32(Minshh[0]);
                                    int salHrs = 0;
                                    if (Minshh.Length > 1)
                                    {
                                        salHrs = Minshh[1].Length > 3 ? Convert.ToInt32(Minshh[1].Substring(0, 2)) : Convert.ToInt32(Minshh[1]);
                                    }
                                    mi = Convert.ToInt32((Convert.ToInt32(salHrs.ToString("###0")) * (0.16666666666666666666666666666667)));
                                }
                                else
                                {
                                    mi = Convert.ToInt32((Convert.ToInt32(hrsMin[1]) * (0.16666666666666666666666666666667)));
                                }
                                string strcon = (Convert.ToString(hr + miHH) + "." + Convert.ToString(mi));
                                ttempHRS = Convert.ToDecimal(strcon);
                                EmpWorkSal = (Convert.ToDecimal(ttempHRS) * Convert.ToDecimal(HRSRate.ToString("######0.000")));
                            }
                            else
                                EmpWorkSal = Convert.ToDecimal("0.000");
                            FinalEmpWorkSal = EmpWorkSal;

                            string HRS = string.Empty; string MIN = string.Empty;
                            if (Salindex.Count > 0)
                            {
                                HRS = Salindex[0].LatencyHours.ToString();
                                MIN = Salindex[0].LatencyMin.ToString();
                            }

                            int LatHRS, LatMIN;
                            if (HRS != "") { LatHRS = Convert.ToInt32(HRS); } else { LatHRS = 0; }
                            if (MIN != "") { LatMIN = Convert.ToInt32(MIN); } else { LatMIN = 0; }

                            //=====================================

                            double SalHRS = (LatHRS * Convert.ToDouble(HRSRate));
                            double calMin; double SalMIN = 0;
                            if (LatMIN > 60)
                            {
                                calMin = (LatMIN / 60);
                                SalMIN = (calMin * Convert.ToInt32(HRSRate));
                            }
                            else
                            {
                                if (LatMIN != 0)
                                { SalMIN = (1 * Convert.ToInt32(HRSRate)); }
                                else { SalMIN = 0; }
                            }
                            double TotSalary = (SalHRS + SalMIN);

                            FinalLaten = Convert.ToDecimal(TotSalary.ToString("######0.000"));
                            //if (GeneralOptionSetting.FlagCutLatencyAutomatically == "Y")
                            //{
                            //    FinalLaten = Convert.ToDecimal(TotSalary.ToString("######0.000"));
                            //}
                            //else
                            //{
                            //    FinalLaten = Convert.ToDecimal(0);
                            //}

                            //-------------------------------"Average calculation"
                            decimal avgall = Convert.ToDecimal((workingday * 6));
                            decimal avgper = Convert.ToDecimal((ttempHRS * 6));
                            decimal aaa = 0;
                            if (avgper != 0 && avgall != 0)
                                aaa = Convert.ToDecimal((avgper / avgall));
                            Avg = aaa; decimal TotSal = 0;
                            //-----------------------------
                            if (index[i].TotalSales.ToString() != string.Empty)
                            {
                                TotSal = Convert.ToDecimal(index[i].TotalSales);
                                ObjSalPay.ObjEmployeeObject.TotalSaleText = TotSal.ToString("#######0.000");
                            }
                            else
                            {
                                ObjSalPay.ObjEmployeeObject.TotalSaleText = TotSal.ToString("#######0.000");
                            }

                            //==============================================

                            #region -=============OverTime/DayOfOverTime Salary=================-
                            if (Salindex.Count > 0)
                            {
                                if (Salindex[0].OverTimings != null)
                                {

                                    Otime = Salindex[0].OverTimings.ToString();
                                    string DayOfOverTime = Salindex[0].DayofOverTime.ToString();
                                    double DayOTcalSal = 0, OTcalSal = 0;
                                    if (Otime != "")
                                    {
                                        char[] chr = { ':' };
                                        string[] OTimeArry = Otime.Split(chr);
                                        string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
                                        string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
                                        int min1 = 0, min2 = 0;
                                        int CalArrymin1 = Convert.ToInt32(getTimeMin1);
                                        if (CalArrymin1 > 59)
                                        {
                                            double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
                                            string AAAA = Convert.ToString(hrrr1.ToString("#####0.000"));
                                            char[] chr1 = { '.' };
                                            string[] MinArry = AAAA.Split(chr1);
                                            min1 = Convert.ToInt32(MinArry[0]);
                                            min2 = Convert.ToInt32(MinArry[1]);

                                            double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs = Convert.ToDouble(Add);
                                            string Hours = dhrs.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours + "." + fin);
                                            if (CalcInteger > 1)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);
                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else { PubOverTime = Convert.ToDouble("0.000"); }
                                        }
                                        else
                                        {
                                            double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs1 = Convert.ToDouble(Add);
                                            string Hours1 = dhrs1.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
                                            if (CalcInteger > 0)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);
                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else
                                            {
                                                PubOverTime = Convert.ToDouble("0.000");
                                            }
                                            double ovrSalary = Convert.ToDouble(Salindex[0].OverTimeSal);
                                            double CalOS = (ovrSalary * PubOverTime);
                                            OTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
                                        }
                                    }
                                    else { Otime = "00"; }
                                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    if (DayOfOverTime != "")
                                    {
                                        char[] chr = { ':' };
                                        string[] OTimeArry = DayOfOverTime.Split(chr);
                                        string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
                                        string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
                                        int min1 = 0, min2 = 0;
                                        int CalArrymin1 = Convert.ToInt32(getTimeMin1);
                                        if (CalArrymin1 > 59)
                                        {
                                            double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
                                            string AAAA = Convert.ToString(hrrr1.ToString("#####0.000"));
                                            char[] chr1 = { '.' };
                                            string[] MinArry = AAAA.Split(chr1);
                                            if (MinArry.Length > 1)
                                            {
                                                min1 = Convert.ToInt32(MinArry[0]);
                                                min2 = Convert.ToInt32(MinArry[1]);
                                            }
                                            double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs = Convert.ToDouble(Add);
                                            string Hours = dhrs.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours + "." + fin);
                                            if (CalcInteger > 1)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);

                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else
                                            {
                                                PubOverTime = Convert.ToDouble("0.000");
                                            }
                                        }
                                        else
                                        {
                                            double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs1 = Convert.ToDouble(Add);
                                            string Hours1 = dhrs1.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
                                            if (CalcInteger > 0)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);

                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else
                                            {
                                                PubOverTime = Convert.ToDouble("0.000");
                                            }
                                            double ovrSalary = Convert.ToDouble(Salindex[0].OverTimeSal.ToString());
                                            double CalOS = (ovrSalary * PubOverTime);
                                            DayOTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
                                        }
                                    }
                                    else
                                    {
                                        Otime = "0.00";
                                    }
                                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    FinalOvrtimeSal = Convert.ToDecimal(OTcalSal + DayOTcalSal);
                                }
                            }
                            #endregion
                            #region -==================Holiday Salary====================-
                            if (Salindex.Count > 0)
                            {
                                HoliTime = Salindex[0].HolidayTimings;
                            }
                            if (HoliTime != "")
                            {
                                char[] chr = { ':' };
                                string[] HoliTimeArry = HoliTime.Split(chr);
                                string getTimeHrs2 = HoliTimeArry.Length > 0 ? HoliTimeArry[0].ToString() : "0";
                                string getTimeMin2 = HoliTimeArry.Length > 0 ? HoliTimeArry[1].ToString() : "0";
                                // string getTimeSec = TimeArry[2].ToString();

                                int min3 = 0, min4 = 0;
                                int CalArrymin2 = Convert.ToInt32(getTimeMin2);
                                if (CalArrymin2 > 59)
                                {
                                    double hrrr2 = (Convert.ToDouble(CalArrymin2) / Convert.ToDouble(60));
                                    string AAAA = Convert.ToString(hrrr2.ToString("####0.000"));
                                    char[] chr1 = { '.' };
                                    string[] HoliMinArry = AAAA.Split(chr1);
                                    min3 = Convert.ToInt32(HoliMinArry[0]);
                                    min4 = Convert.ToInt32(HoliMinArry[1]);

                                    double HoliCalMin1 = (Convert.ToDouble(min4) * (0.16666666666666666666666666666667));
                                    string finHoli = HoliCalMin1.ToString("###0");
                                    int Add1 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
                                    double Holidhrs = Convert.ToDouble(Add1);
                                    string HoliHours = Holidhrs.ToString("###0");

                                    double HoliCalcInteger = Convert.ToDouble(HoliHours + "." + finHoli);
                                    if (HoliCalcInteger > 1)
                                    {
                                        double HoliSal1 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(HoliHours));
                                        double HoliSal2 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(finHoli) / 60);
                                        double HoliTotWeeklySalary = Convert.ToDouble(HoliSal1 + HoliSal2);
                                        PubHoliday = Convert.ToDouble(HoliTotWeeklySalary.ToString("######0.000"));
                                    }
                                    else
                                        PubHoliday = Convert.ToDouble("0.000");
                                }
                                else
                                {
                                    double HoliCalMin1 = (Convert.ToDouble(CalArrymin2) * (0.16666666666666666666666666666667));
                                    string Holifin = HoliCalMin1.ToString("###0");
                                    int Add3 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
                                    double Holidhrs1 = Convert.ToDouble(Add3);
                                    string HoliHours1 = Holidhrs1.ToString("###0");

                                    double CalcIntegerHoli = Convert.ToDouble(HoliHours1 + "." + Holifin);

                                    if (CalcIntegerHoli > 1)
                                    {
                                        double HoliSal3 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(HoliHours1));
                                        double HoliSal4 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(Holifin) / 60);

                                        double HoliTotWeeklySalary1 = Convert.ToDouble(HoliSal3 + HoliSal4);
                                        PubHoliday = Convert.ToDouble(HoliTotWeeklySalary1.ToString("######0.000"));

                                    }
                                    else
                                        PubHoliday = Convert.ToDouble("0.000");
                                }
                            }
                            else
                            {
                                HoliTime = "00";
                                PubHoliday = Convert.ToDouble("0.000");
                            }
                            FinalHolidaySal = Convert.ToDecimal(PubHoliday);
                            #endregion

                            DrawAmt = (index[i].DrawAmt.ToString() != "") ? Convert.ToDecimal(index[i].DrawAmt) : 0;

                        }

                        #region =============="Variable Amt bind coding"===============
                        decimal Advance = 0, Punishment = 0, Neglet = 0, Others = 0, Reward = 0, Incentives = 0;
                        var VariableIndex = dicSalHelper["EmpVariabledetails"].FindAll(x => x.CalcType == ViewType);
                        for (int j = 0; j < VariableIndex.Count; j++)
                        {
                            int UserId = VariableIndex[j].UserId;
                            if (EMPID == UserId)
                            {
                                int varid = VariableIndex[j].VariableID;
                                varAmt = Convert.ToDecimal(VariableIndex[j].MonthlyDeduction);
                                decimal varAmt1 = Convert.ToDecimal(VariableIndex[j].VariableAmount);
                                if (varid == 101) { Advance = varAmt; TotAmt += varAmt; }
                                if (varid == 102) { Punishment = varAmt; TotAmt += varAmt; }
                                if (varid == 103) { Neglet = varAmt; TotAmt += varAmt; }
                                if (varid == 104) { Reward = varAmt1; ADDTotAmt += varAmt1; }
                                if (varid == 105) { Incentives = varAmt1; ADDTotAmt += varAmt1; }
                                if (varid == 106) { Others = varAmt; TotAmt += varAmt; }
                                //break;
                            }
                        }

                        #endregion

                        decimal Netsalary = 0, TotBaseOver = 0;
                        Netsalary = Convert.ToDecimal((FinalEmpWorkSal + FinalOvrtimeSal + FinalHolidaySal + ADDTotAmt) - (TotAmt + DrawAmt + FinalLaten));
                        TotBaseOver = Convert.ToDecimal((FinalEmpWorkSal + FinalOvrtimeSal + FinalHolidaySal + ADDTotAmt));
                        if (index.Count > 0)
                        {
                            decimal TotSal = 0;
                            for (int n = 0; n < index.Count; n++)
                            {
                                if (index != null)
                                { TotSal += Convert.ToDecimal(index[n].TotalSales); }
                                else { TotSal += 0; }
                            }
                            ObjSalPay.ObjEmployeeObject.TotalSaleText = TotSal.ToString("######0.000");
                        }
                        string saltype = string.Empty;
                        if (index[i].CalcType.ToString() == "0") saltype = "Monthly";
                        if (index[i].CalcType.ToString() == "1") saltype = "Weekly";
                        if (index[i].CalcType.ToString() == "2") saltype = "Hourly";
                        if (index[i].CalcType.ToString() == "3") saltype = "Percentage";
                        listSalHelper.Add(new EmployeeObjectClass
                        {
                            Select = false,
                            EmpId = index[i].UserId,
                            EmpName = index[i].FirstName,
                            CalcType = index[i].CalcType,
                            saltype = saltype,
                            BasicSalary = Convert.ToDecimal(index[i].BasicSalary.ToString("######0.000")),
                            OverTimeSal = Convert.ToDecimal(index[i].OverTimeSal.ToString("######0.000")),
                            HolidaySal = Convert.ToDecimal(index[i].HolidaySal.ToString("######0.000")),
                            SalaryForPerDay = Convert.ToDecimal(OneDayRate.ToString("######0.000")),
                            SalaryForPerHour = Convert.ToDecimal(HRSRate.ToString("######0.000")),
                            EmpSalary = Convert.ToDecimal(FinalEmpWorkSal.ToString("######0.000")),
                            Average = Convert.ToDecimal(Avg.ToString("######0.000")),
                            OverTimings = Otime,
                            EmpOverSalary = Convert.ToDecimal(FinalOvrtimeSal.ToString("######0.000")),
                            HolidayOverTime = HoliTime,
                            EmpHoliSalary = Convert.ToDecimal(PubHoliday.ToString("######0.000")),
                            DrawAmt = Convert.ToDecimal(DrawAmt.ToString("######0.000")),
                            Advance = Convert.ToDecimal(Advance.ToString("######0.000")),
                            Punishment = Convert.ToDecimal(Punishment.ToString("######0.000")),
                            Neglect = Convert.ToDecimal(Neglet.ToString("######0.000")),
                            Reward = Convert.ToDecimal(Reward.ToString("######0.000")),
                            Incentive = Convert.ToDecimal(Incentives.ToString("######0.000")),
                            Others = Convert.ToDecimal(Others.ToString("######0.000")),
                            WorkingDays = TotalDays,
                            WorkedDays = EmpPresentDays,
                            LatencyAmt = Convert.ToDecimal(FinalLaten.ToString("######0.000")),
                            NetSalary = Convert.ToDecimal(Netsalary.ToString("######0.000")),
                        });

                        TotAmt = 0;
                        ADDTotAmt = 0;

                    }

                }
                CalculateTotal();
            }
            // DataTable dts = ConvertToDataTable(listSalHelper);
            return listSalHelper;

        }
        #endregion

        //#region FillDatasInGridViewByWEEKLY()
        //public List<EmployeeObjectClass> FillDatasInGridViewByWEEKLY()
        //{
        //    int EMPID;
        //    decimal baseSal = 0, OvrtimeSal = 0; decimal Avg = 0;
        //    string Otime = string.Empty; string HoliTime = string.Empty;
        //    int TotalDays = 0, EmpPresentDays = 0;
        //    listSalHelper.Clear();
        //    if (dicSalHelper != null)
        //    {
        //        var index = dicSalHelper["EmpBasicdetails"].FindAll(x => x.CalcType == ViewType);
        //        for (int i = 0; i < index.Count; i++)
        //        {
        //            int system = index[i].CalcType;

        //            //-----------------------------------------
        //            if (system == ViewType)
        //            {
        //                EMPID = index[i].UserId;
        //                decimal Base = index[i].BasicSalary;
        //                decimal OSal = index[i].OverTimeSal;
        //                decimal HSal = index[i].HolidaySal;
        //                baseSal = Convert.ToDecimal(Base);
        //                OvrtimeSal = Convert.ToDecimal(OSal);
        //                string hrsinday = index[i].EmpWorkHrs.ToString();
        //                int CalHRS = 0;
        //                if (hrsinday != "")
        //                {
        //                    string[] ssss = hrsinday.Split(':');
        //                    CalHRS = Convert.ToInt32((Convert.ToInt32(ssss[0])) + (Convert.ToInt32(ssss[1]) * (0.16666666666666666666666666666667)));
        //                }
        //                int GetWeekend, MonthHolidays = 0;
        //                if (dicSalHelper["EmpWeekOffDetails"] != null)
        //                {
        //                    var WeekOffindex = dicSalHelper["EmpWeekOffDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
        //                    if (WeekOffindex != null)
        //                    {
        //                        GetWeekend = WeekOffindex[0].WeekEnd;
        //                        if (GetWeekend == 1)
        //                            MonthHolidays = WeekOffindex[0].Suncount;
        //                        else if (GetWeekend == 2)
        //                            MonthHolidays = WeekOffindex[0].Moncount;
        //                        else if (GetWeekend == 2)
        //                            MonthHolidays = WeekOffindex[0].Tuescount;
        //                        else if (GetWeekend == 2)
        //                            MonthHolidays = WeekOffindex[0].Wedcount;
        //                        else if (GetWeekend == 2)
        //                            MonthHolidays = WeekOffindex[0].Thurscount;
        //                        else if (GetWeekend == 2)
        //                            MonthHolidays = WeekOffindex[0].Fricount;
        //                        else
        //                            MonthHolidays = WeekOffindex[0].Satcount;
        //                    }
        //                    else
        //                    {
        //                        GetWeekend = 0;
        //                        MonthHolidays = 0;
        //                    }
        //                }
        //                int ttday = 30;
        //                int holiday = Convert.ToInt32(MonthHolidays);
        //                int workingday = (ttday - holiday);
        //                int worHRSperMon = (CalHRS * workingday);
        //                decimal HRSRate = (baseSal / worHRSperMon);
        //                decimal OneDayRate = (CalHRS * Convert.ToDecimal(HRSRate.ToString("########0.000")));
        //                if (dicSalHelper["EmpSalDetails"] != null)
        //                {
        //                    var Salindex = dicSalHelper["EmpSalDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
        //                    string TotalWorkedHRS = Salindex[0].WorkTimings;
        //                    TotalDays = Salindex[0].WorkingDays;
        //                    EmpPresentDays = Salindex[0].WorkedDays;
        //                    double hr = 0, mi = 0; decimal ttempHRS = 0;
        //                    decimal EmpWorkSal = 0;
        //                    int miHH = 0;
        //                    if (TotalWorkedHRS != "")
        //                    {
        //                        string[] hrsMin = TotalWorkedHRS.Split(':');
        //                        hr = Convert.ToInt32(hrsMin[0]);

        //                        if (Convert.ToInt32(hrsMin[1]) > 60)
        //                        {
        //                            decimal vval = (Convert.ToDecimal(hrsMin[1]) / 60);
        //                            string[] Minshh = vval.ToString().Split('.');
        //                            miHH = Convert.ToInt32(Minshh[0]);
        //                            int salHrs = Minshh[1].Length > 3 ? Convert.ToInt32(Minshh[1].Substring(0, 2)) : Convert.ToInt32(Minshh[1]);
        //                            mi = Convert.ToInt32((Convert.ToInt32(salHrs.ToString("###0")) * (0.16666666666666666666666666666667)));
        //                        }
        //                        else
        //                        {
        //                            mi = Convert.ToInt32((Convert.ToInt32(hrsMin[1]) * (0.16666666666666666666666666666667)));
        //                        }
        //                        string strcon = (Convert.ToString(hr + miHH) + "." + Convert.ToString(mi));
        //                        ttempHRS = Convert.ToDecimal(strcon);
        //                        EmpWorkSal = (Convert.ToDecimal(ttempHRS) * Convert.ToDecimal(HRSRate.ToString("######0.000")));
        //                    }
        //                    else
        //                        EmpWorkSal = Convert.ToDecimal("0.000");
        //                    FinalEmpWorkSal = EmpWorkSal;

        //                    string HRS = Salindex[0].LatencyHours.ToString();
        //                    string MIN = Salindex[0].LatencyMin.ToString();

        //                    int LatHRS, LatMIN;
        //                    if (HRS != "") { LatHRS = Convert.ToInt32(HRS); } else { LatHRS = 0; }
        //                    if (MIN != "") { LatMIN = Convert.ToInt32(MIN); } else { LatMIN = 0; }

        //                    //=====================================

        //                    double SalHRS = (LatHRS * Convert.ToDouble(HRSRate));
        //                    double calMin; double SalMIN = 0;
        //                    if (LatMIN > 60)
        //                    {
        //                        calMin = (LatMIN / 60);
        //                        SalMIN = (calMin * Convert.ToInt32(HRSRate));
        //                    }
        //                    else
        //                    {
        //                        if (LatMIN != 0)
        //                        { SalMIN = (1 * Convert.ToInt32(HRSRate)); }
        //                        else { SalMIN = 0; }
        //                    }
        //                    double TotSalary = (SalHRS + SalMIN);

        //                    FinalLaten = Convert.ToDecimal(TotSalary.ToString("######0.000"));
        //                    //if (GeneralOptionSetting.FlagCutLatencyAutomatically == "Y")
        //                    //{
        //                    //    FinalLaten = Convert.ToDecimal(TotSalary.ToString("######0.000"));
        //                    //}
        //                    //else
        //                    //{
        //                    //    FinalLaten = Convert.ToDecimal(0);
        //                    //}

        //                    //-------------------------------"Average calculation"
        //                    decimal avgall = Convert.ToDecimal((workingday * 6));
        //                    decimal avgper = Convert.ToDecimal((ttempHRS * 6));
        //                    decimal aaa = Convert.ToDecimal((avgper / avgall));
        //                    Avg = aaa;
        //                    //-----------------------------
        //                    if (index[i].TotalSales.ToString() != string.Empty)
        //                    {

        //                        decimal TotSal = Convert.ToDecimal(index[i].TotalSales);
        //                        //-----------------------------------------------Txt_TotalSales.Text = TotSal.ToString("#######0.000");---------------------------------//
        //                    }
        //                    else
        //                    {
        //                        //-----------------------------------------------Txt_TotalSales.Text = TotSal.ToString("#######0.000");---------------------------------//
        //                    }

        //                    //==============================================

        //                    #region -=============OverTime/DayOfOverTime Salary=================-
        //                    if (Salindex[0].OverTimings != null)
        //                    {

        //                        Otime = Salindex[0].OverTimings.ToString();
        //                        string DayOfOverTime = Salindex[0].DayofOverTime.ToString();
        //                        double DayOTcalSal = 0, OTcalSal = 0;
        //                        if (Otime != "")
        //                        {
        //                            char[] chr = { ':' };
        //                            string[] OTimeArry = Otime.Split(chr);
        //                            string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
        //                            string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
        //                            int min1 = 0, min2 = 0;
        //                            int CalArrymin1 = Convert.ToInt32(getTimeMin1);
        //                            if (CalArrymin1 > 59)
        //                            {
        //                                double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
        //                                string AAAA = Convert.ToString(hrrr1.ToString("###0.00"));
        //                                char[] chr1 = { '.' };
        //                                string[] MinArry = AAAA.Split(chr1);
        //                                min1 = Convert.ToInt32(MinArry[0]);
        //                                min2 = Convert.ToInt32(MinArry[1]);

        //                                double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
        //                                string fin = CalMin1.ToString("###0");
        //                                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
        //                                double dhrs = Convert.ToDouble(Add);
        //                                string Hours = dhrs.ToString("###0");
        //                                double CalcInteger = Convert.ToDouble(Hours + "." + fin);
        //                                if (CalcInteger > 1)
        //                                {
        //                                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
        //                                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);
        //                                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
        //                                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
        //                                }
        //                                else { PubOverTime = Convert.ToDouble("0.000"); }
        //                            }
        //                            else
        //                            {
        //                                double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
        //                                string fin = CalMin1.ToString("###0");
        //                                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
        //                                double dhrs1 = Convert.ToDouble(Add);
        //                                string Hours1 = dhrs1.ToString("###0");
        //                                double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
        //                                if (CalcInteger > 0)
        //                                {
        //                                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
        //                                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);
        //                                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
        //                                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
        //                                }
        //                                else
        //                                {
        //                                    PubOverTime = Convert.ToDouble("0.000");
        //                                }
        //                                double ovrSalary = Convert.ToDouble(Salindex[i].OverTimeSal);
        //                                double CalOS = (ovrSalary * PubOverTime);
        //                                OTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
        //                            }
        //                        }
        //                        else { Otime = "00"; }
        //                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                        if (DayOfOverTime != "")
        //                        {
        //                            char[] chr = { ':' };
        //                            string[] OTimeArry = DayOfOverTime.Split(chr);
        //                            string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
        //                            string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
        //                            int min1 = 0, min2 = 0;
        //                            int CalArrymin1 = Convert.ToInt32(getTimeMin1);
        //                            if (CalArrymin1 > 59)
        //                            {
        //                                double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
        //                                string AAAA = Convert.ToString(hrrr1.ToString("###0.00"));
        //                                char[] chr1 = { '.' };
        //                                string[] MinArry = AAAA.Split(chr1);
        //                                min1 = Convert.ToInt32(MinArry[0]);
        //                                min2 = Convert.ToInt32(MinArry[1]);
        //                                double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
        //                                string fin = CalMin1.ToString("###0");
        //                                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
        //                                double dhrs = Convert.ToDouble(Add);
        //                                string Hours = dhrs.ToString("###0");
        //                                double CalcInteger = Convert.ToDouble(Hours + "." + fin);
        //                                if (CalcInteger > 1)
        //                                {
        //                                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
        //                                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);

        //                                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
        //                                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
        //                                }
        //                                else
        //                                {
        //                                    PubOverTime = Convert.ToDouble("0.000");
        //                                }
        //                            }
        //                            else
        //                            {
        //                                double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
        //                                string fin = CalMin1.ToString("###0");
        //                                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
        //                                double dhrs1 = Convert.ToDouble(Add);
        //                                string Hours1 = dhrs1.ToString("###0");
        //                                double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
        //                                if (CalcInteger > 0)
        //                                {
        //                                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
        //                                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);

        //                                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
        //                                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
        //                                }
        //                                else
        //                                {
        //                                    PubOverTime = Convert.ToDouble("0.000");
        //                                }
        //                                double ovrSalary = Convert.ToDouble(Salindex[i].OverTimeSal.ToString());
        //                                double CalOS = (ovrSalary * PubOverTime);
        //                                DayOTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Otime = "0.00";
        //                        }
        //                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                        FinalOvrtimeSal = Convert.ToDecimal(OTcalSal + DayOTcalSal);
        //                    }
        //                    #endregion
        //                    #region -==================Holiday Salary====================-

        //                    HoliTime = Salindex[0].HolidayTimings;
        //                    if (HoliTime != "")
        //                    {
        //                        char[] chr = { ':' };
        //                        string[] HoliTimeArry = HoliTime.Split(chr);
        //                        string getTimeHrs2 = HoliTimeArry.Length > 0 ? HoliTimeArry[0].ToString() : "0";
        //                        string getTimeMin2 = HoliTimeArry.Length > 0 ? HoliTimeArry[1].ToString() : "0";
        //                        // string getTimeSec = TimeArry[2].ToString();

        //                        int min3 = 0, min4 = 0;
        //                        int CalArrymin2 = Convert.ToInt32(getTimeMin2);
        //                        if (CalArrymin2 > 59)
        //                        {
        //                            double hrrr2 = (Convert.ToDouble(CalArrymin2) / Convert.ToDouble(60));
        //                            string AAAA = Convert.ToString(hrrr2.ToString("####0.00"));
        //                            char[] chr1 = { '.' };
        //                            string[] HoliMinArry = AAAA.Split(chr1);
        //                            min3 = Convert.ToInt32(HoliMinArry[0]);
        //                            min4 = Convert.ToInt32(HoliMinArry[1]);

        //                            double HoliCalMin1 = (Convert.ToDouble(min4) * (0.16666666666666666666666666666667));
        //                            string finHoli = HoliCalMin1.ToString("###0");
        //                            int Add1 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
        //                            double Holidhrs = Convert.ToDouble(Add1);
        //                            string HoliHours = Holidhrs.ToString("###0");

        //                            double HoliCalcInteger = Convert.ToDouble(HoliHours + "." + finHoli);
        //                            if (HoliCalcInteger > 1)
        //                            {
        //                                double HoliSal1 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(HoliHours));
        //                                double HoliSal2 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(finHoli) / 60);
        //                                double HoliTotWeeklySalary = Convert.ToDouble(HoliSal1 + HoliSal2);
        //                                PubHoliday = Convert.ToDouble(HoliTotWeeklySalary.ToString("######0.000"));
        //                            }
        //                            else
        //                                PubHoliday = Convert.ToDouble("0.000");
        //                        }
        //                        else
        //                        {
        //                            double HoliCalMin1 = (Convert.ToDouble(CalArrymin2) * (0.16666666666666666666666666666667));
        //                            string Holifin = HoliCalMin1.ToString("###0");
        //                            int Add3 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
        //                            double Holidhrs1 = Convert.ToDouble(Add3);
        //                            string HoliHours1 = Holidhrs1.ToString("###0");

        //                            double CalcIntegerHoli = Convert.ToDouble(HoliHours1 + "." + Holifin);

        //                            if (CalcIntegerHoli > 1)
        //                            {
        //                                double HoliSal3 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(HoliHours1));
        //                                double HoliSal4 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(Holifin) / 60);

        //                                double HoliTotWeeklySalary1 = Convert.ToDouble(HoliSal3 + HoliSal4);
        //                                PubHoliday = Convert.ToDouble(HoliTotWeeklySalary1.ToString("######0.000"));

        //                            }
        //                            else
        //                                PubHoliday = Convert.ToDouble("0.000");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        HoliTime = "00";
        //                        PubHoliday = Convert.ToDouble("0.000");
        //                    }
        //                    FinalHolidaySal = Convert.ToDecimal(PubHoliday);
        //                    #endregion

        //                    DrawAmt = (index[i].VariableAmount.ToString() != "") ? Convert.ToDecimal(index[i].VariableAmount) : 0;

        //                }

        //                #region =============="Variable Amt bind coding"===============
        //                decimal Advance = 0, Punishment = 0, Neglet = 0, Others = 0, Reward = 0, Incentives = 0;
        //                var VariableIndex = dicSalHelper["EmpVariabledetails"].FindAll(x => x.CalcType == ViewType);
        //                for (int j = 0; j < VariableIndex.Count; j++)
        //                {
        //                    int UserId = VariableIndex[j].UserId;
        //                    if (EMPID == UserId)
        //                    {
        //                        int varid = VariableIndex[j].VariableID;
        //                        varAmt = Convert.ToDecimal(VariableIndex[j].MonthlyDeduction);
        //                        decimal varAmt1 = Convert.ToDecimal(VariableIndex[j].VariableAmount);
        //                        if (varid == 101) { Advance = varAmt; TotAmt += varAmt; }
        //                        if (varid == 102) { Punishment = varAmt; TotAmt += varAmt; }
        //                        if (varid == 103) { Neglet = varAmt; TotAmt += varAmt; }
        //                        if (varid == 104) { Others = varAmt; TotAmt += varAmt; }
        //                        if (varid == 105) { Reward = varAmt; ADDTotAmt += varAmt1; }
        //                        if (varid == 106) { Incentives = varAmt; TotAmt += varAmt; ADDTotAmt += varAmt1; }
        //                    }
        //                }

        //                #endregion

        //                decimal Netsalary = 0, TotBaseOver = 0;
        //                Netsalary = Convert.ToDecimal((FinalEmpWorkSal + FinalOvrtimeSal + FinalHolidaySal + ADDTotAmt) - (TotAmt + DrawAmt + FinalLaten));
        //                TotBaseOver = Convert.ToDecimal((FinalEmpWorkSal + FinalOvrtimeSal + FinalHolidaySal + ADDTotAmt));
        //                if (index.Count > 0)
        //                {
        //                    decimal TotSal = 0;
        //                    for (int n = 0; n < index.Count; n++)
        //                    {
        //                        if (index != null)
        //                        { TotSal += Convert.ToDecimal(index[n].TotalSales); }
        //                        else { TotSal += 0; }
        //                    }
        //                    ObjSalPay.ObjEmployeeObject.TotalSaleText = TotSal.ToString("######0.000");
        //                }
        //                string saltype = string.Empty;
        //                if (index[i].CalcType.ToString() == "0") saltype = "Monthly";
        //                if (index[i].CalcType.ToString() == "1") saltype = "Weekly";
        //                if (index[i].CalcType.ToString() == "2") saltype = "Hourly";
        //                if (index[i].CalcType.ToString() == "3") saltype = "Percentage";
        //                listSalHelper.Add(new EmployeeObjectClass
        //                {
        //                    Select = false,
        //                    EmpId = index[i].UserId,
        //                    EmpName = index[i].FirstName,
        //                    CalcType = index[i].CalcType,
        //                    saltype = saltype,
        //                    BasicSalary = Convert.ToDecimal(index[i].BasicSalary.ToString("######0.000")),
        //                    OverTimeSal = Convert.ToDecimal(index[i].OverTimeSal.ToString("######0.000")),
        //                    HolidaySal = Convert.ToDecimal(index[i].HolidaySal.ToString("######0.000")),
        //                    SalaryForPerDay = Convert.ToDecimal(OneDayRate.ToString("######0.000")),
        //                    SalaryForPerHour = Convert.ToDecimal(HRSRate.ToString("######0.000")),
        //                    EmpSalary = Convert.ToDecimal(FinalEmpWorkSal.ToString("######0.000")),
        //                    Average = Convert.ToDecimal(Avg.ToString("######0.000")),
        //                    OverTimings = Otime,
        //                    EmpOverSalary = Convert.ToDecimal(FinalOvrtimeSal.ToString("######0.000")),
        //                    HolidayOverTime = HoliTime,
        //                    EmpHoliSalary = Convert.ToDecimal(PubHoliday.ToString("######0.000")),
        //                    DrawAmt = Convert.ToDecimal(DrawAmt.ToString("######0.000")),
        //                    Advance = Convert.ToDecimal(Advance.ToString("######0.000")),
        //                    Punishment = Convert.ToDecimal(Punishment.ToString("######0.000")),
        //                    Neglect = Convert.ToDecimal(Neglet.ToString("######0.000")),
        //                    Reward = Convert.ToDecimal(Reward.ToString("######0.000")),
        //                    Incentive = Convert.ToDecimal(Incentives.ToString("######0.000")),
        //                    Others = Convert.ToDecimal(Others.ToString("######0.000")),
        //                    WorkingDays = TotalDays,
        //                    WorkedDays = EmpPresentDays,
        //                    LatencyAmt = Convert.ToDecimal(FinalLaten.ToString("######0.000")),
        //                    NetSalary = Convert.ToDecimal(Netsalary.ToString("######0.000")),
        //                });
        //                TotAmt = 0;
        //                ADDTotAmt = 0;
        //            }
        //        }
        //    }
        //    return listSalHelper;
        //}
        //#endregion

        #region FillDatasInGridViewByHOURLY()
        public List<EmployeeObjectClass> FillDatasInGridViewByHOURLY(int ViewType)
        {
            int EMPID;
            decimal baseSal = 0, OvrtimeSal = 0; decimal Avg = 0;
            string Otime = string.Empty; string HoliTime = string.Empty;
            int TotalDays = 0, EmpPresentDays = 0; string TotalOverTime = string.Empty;
            FinalOvrtimeSal = 0;
            if (ObjSalPay.ObjEmployeeObject.chkAllEmployee != true)
            {
                listSalHelper.Clear();
            }
            if (dicSalHelper != null)
            {
                var index = dicSalHelper["EmpBasicdetails"].FindAll(x => x.CalcType == ViewType);
                for (int i = 0; i < index.Count; i++)
                {
                    int system = index[i].CalcType;

                    //-----------------------------------------
                    if (system == ViewType)
                    {
                        EMPID = index[i].UserId;
                        decimal Base = index[i].BasicSalary;
                        decimal OSal = index[i].OverTimeSal;
                        decimal HSal = index[i].HolidaySal;
                        baseSal = Convert.ToDecimal(Base);
                        OvrtimeSal = Convert.ToDecimal(OSal);
                        string hrsinday = index[i].EmpWorkHrs.ToString();
                        int CalHRS = 0;
                        if (hrsinday != "")
                        {
                            string[] ssss = hrsinday.Split(':');
                            CalHRS = Convert.ToInt32((Convert.ToInt32(ssss[0])) + (Convert.ToInt32(ssss[1]) * (0.16666666666666666666666666666667)));
                        }
                        int GetWeekend, MonthHolidays = 0;
                        if (dicSalHelper["EmpWeekOffDetails"] != null)
                        {
                            var WeekOffindex = dicSalHelper["EmpWeekOffDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
                            if (WeekOffindex.Count > 0)
                            {
                                GetWeekend = WeekOffindex[0].WeekEnd;
                                if (GetWeekend == 1)
                                    MonthHolidays = WeekOffindex[0].Suncount;
                                else if (GetWeekend == 2)
                                    MonthHolidays = WeekOffindex[0].Moncount;
                                else if (GetWeekend == 3)
                                    MonthHolidays = WeekOffindex[0].Tuescount;
                                else if (GetWeekend == 4)
                                    MonthHolidays = WeekOffindex[0].Wedcount;
                                else if (GetWeekend == 5)
                                    MonthHolidays = WeekOffindex[0].Thurscount;
                                else if (GetWeekend == 6)
                                    MonthHolidays = WeekOffindex[0].Fricount;
                                else
                                    MonthHolidays = WeekOffindex[0].Satcount;
                            }
                            else
                            {
                                GetWeekend = 0;
                                MonthHolidays = 0;
                            }
                        }
                        int ttday = 30;
                        int holiday = Convert.ToInt32(MonthHolidays);
                        int workingday = (ttday - holiday);
                        int worHRSperMon = (CalHRS * workingday);
                        decimal HRSRate = OvrtimeSal;
                        decimal OneDayRate = (CalHRS * Convert.ToDecimal(HRSRate.ToString("########0.000")));

                        if (dicSalHelper["EmpSalDetails"] != null)
                        {
                            var Salindex = dicSalHelper["EmpSalDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
                            string TotalWorkedHRS = string.Empty;
                            if (Salindex.Count > 0)
                            {
                                string[] sumTotalWorkedHRS = ((Salindex[0].WorkTimings != null) && (Salindex[0].WorkTimings.ToString() != "")) ? Salindex[0].WorkTimings.ToString().Split(':') : "00:00".Split(':');
                                string[] sumovertime = ((Salindex[0].OverTimings != null) && (Salindex[0].OverTimings.ToString() != "")) ? Salindex[0].OverTimings.ToString().Split(':') : "00:00".Split(':');
                                string[] sumDayofovertime = ((Salindex[0].DayofOverTime != null) && (Salindex[0].DayofOverTime.ToString() != "")) ? Salindex[0].DayofOverTime.ToString().Split(':') : "00:00".Split(':');
                                decimal totalsumhr = Convert.ToDecimal(sumTotalWorkedHRS[0]) + Convert.ToDecimal(sumovertime[0]);// +Convert.ToDecimal(sumDayofovertime[0]);
                                // decimal totalsumhr = Convert.ToDecimal(sumTotalWorkedHRS[0]) + Convert.ToDecimal(sumovertime[0]) + Convert.ToDecimal(sumDayofovertime[0]);
                                decimal totalsummin = Convert.ToDecimal((sumTotalWorkedHRS.Length > 1) ? sumTotalWorkedHRS[1] : "0");// + Convert.ToDecimal((sumovertime.Length > 1) ? sumovertime[1] : "0") + Convert.ToDecimal((sumDayofovertime.Length > 1) ? sumDayofovertime[1] : "0");

                                decimal totalOversumhr = Convert.ToDecimal(sumDayofovertime[0]) + Convert.ToDecimal(sumDayofovertime[0]);
                                decimal totalOversummin = Convert.ToDecimal((sumDayofovertime.Length > 1) ? sumDayofovertime[1] : "0");

                                TotalWorkedHRS = totalsumhr + ":" + totalsummin;
                                TotalDays = Salindex[0].WorkingDays;
                                EmpPresentDays = Salindex[0].WorkedDays;
                                TotalOverTime = totalOversumhr + ":" + totalOversummin;
                            }
                            double hr = 0, mi = 0; decimal ttempHRS = 0;
                            decimal EmpWorkSal = 0;
                            int miHH = 0;
                            if (TotalWorkedHRS != "")
                            {
                                string[] hrsMin = TotalWorkedHRS.Split(':');
                                hr = Convert.ToInt32(hrsMin[0]);

                                if (Convert.ToInt32(hrsMin[1]) > 60)
                                {
                                    decimal vval = (Convert.ToDecimal(hrsMin[1]) / 60);
                                    string[] Minshh = vval.ToString().Split('.');
                                    miHH = Convert.ToInt32(Minshh[0]);
                                    int salHrs = 0;
                                    if (Minshh.Length > 1)
                                    {
                                        salHrs = Minshh[1].Length > 3 ? Convert.ToInt32(Minshh[1].Substring(0, 2)) : Convert.ToInt32(Minshh[1]);
                                    }
                                    mi = Convert.ToInt32((Convert.ToInt32(salHrs.ToString("###0")) * (0.16666666666666666666666666666667)));
                                }
                                else
                                {
                                    mi = Convert.ToInt32((Convert.ToInt32(hrsMin[1]) * (0.16666666666666666666666666666667)));
                                }
                                string strcon = (Convert.ToString(hr + miHH) + "." + Convert.ToString(mi));
                                ttempHRS = Convert.ToDecimal(strcon);
                                EmpWorkSal = (Convert.ToDecimal(ttempHRS) * Convert.ToDecimal(HRSRate.ToString("######0.000")));
                            }
                            else
                                EmpWorkSal = Convert.ToDecimal("0.000");
                            FinalEmpWorkSal = EmpWorkSal;

                            string HRS = string.Empty; string MIN = string.Empty;
                            if (Salindex.Count > 0)
                            {
                                HRS = Salindex[0].LatencyHours.ToString();
                                MIN = Salindex[0].LatencyMin.ToString();
                            }

                            int LatHRS, LatMIN;
                            if (HRS != "") { LatHRS = Convert.ToInt32(HRS); } else { LatHRS = 0; }
                            if (MIN != "") { LatMIN = Convert.ToInt32(MIN); } else { LatMIN = 0; }

                            //=====================================

                            double SalHRS = (LatHRS * Convert.ToDouble(HRSRate));
                            double calMin; double SalMIN = 0;
                            if (LatMIN > 60)
                            {
                                calMin = (LatMIN / 60);
                                SalMIN = (calMin * Convert.ToInt32(HRSRate));
                            }
                            else
                            {
                                if (LatMIN != 0)
                                { SalMIN = (1 * Convert.ToInt32(HRSRate)); }
                                else { SalMIN = 0; }
                            }
                            double TotSalary = (SalHRS + SalMIN);

                            FinalLaten = Convert.ToDecimal(TotSalary.ToString("######0.000"));
                            //if (GeneralOptionSetting.FlagCutLatencyAutomatically == "Y")
                            //{
                            //    FinalLaten = Convert.ToDecimal(TotSalary.ToString("######0.000"));
                            //}
                            //else
                            //{
                            //    FinalLaten = Convert.ToDecimal(0);
                            //}

                            //-------------------------------"Average calculation"
                            decimal avgall = Convert.ToDecimal((workingday * 6));
                            decimal avgper = Convert.ToDecimal((ttempHRS * 6));
                            decimal aaa = Convert.ToDecimal((avgper / avgall));
                            Avg = aaa;
                            //-----------------------------
                            if (index[i].TotalSales.ToString() != string.Empty)
                            {

                                decimal TotSal = Convert.ToDecimal(index[i].TotalSales);
                                //-----------------------------------------------Txt_TotalSales.Text = TotSal.ToString("#######0.000");---------------------------------//
                            }
                            else
                            {
                                //-----------------------------------------------Txt_TotalSales.Text = TotSal.ToString("#######0.000");---------------------------------//
                            }

                            //==============================================

                            #region -=============OverTime/DayOfOverTime Salary=================-
                            //if (Salindex.Count > 0)
                            //{
                            //    if (Salindex[0].OverTimings != null)
                            //    {

                            //        Otime = Salindex[0].OverTimings.ToString();
                            //        string DayOfOverTime = Salindex[0].DayofOverTime.ToString();
                            //        double DayOTcalSal = 0, OTcalSal = 0;
                            //        if (Otime != "")
                            //        {
                            //            char[] chr = { ':' };
                            //            string[] OTimeArry = Otime.Split(chr);
                            //            string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
                            //            string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
                            //            int min1 = 0, min2 = 0;
                            //            int CalArrymin1 = Convert.ToInt32(getTimeMin1);
                            //            if (CalArrymin1 > 59)
                            //            {
                            //                double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
                            //                string AAAA = Convert.ToString(hrrr1.ToString("###0.00"));
                            //                char[] chr1 = { '.' };
                            //                string[] MinArry = AAAA.Split(chr1);
                            //                min1 = Convert.ToInt32(MinArry[0]);
                            //                min2 = Convert.ToInt32(MinArry[1]);

                            //                double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
                            //                string fin = CalMin1.ToString("###0");
                            //                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                            //                double dhrs = Convert.ToDouble(Add);
                            //                string Hours = dhrs.ToString("###0");
                            //                double CalcInteger = Convert.ToDouble(Hours + "." + fin);
                            //                if (CalcInteger > 1)
                            //                {
                            //                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
                            //                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);
                            //                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                            //                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                            //                }
                            //                else { PubOverTime = Convert.ToDouble("0.000"); }
                            //            }
                            //            else
                            //            {
                            //                double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
                            //                string fin = CalMin1.ToString("###0");
                            //                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                            //                double dhrs1 = Convert.ToDouble(Add);
                            //                string Hours1 = dhrs1.ToString("###0");
                            //                double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
                            //                if (CalcInteger > 0)
                            //                {
                            //                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
                            //                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);
                            //                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                            //                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                            //                }
                            //                else
                            //                {
                            //                    PubOverTime = Convert.ToDouble("0.000");
                            //                }
                            //                double ovrSalary = Convert.ToDouble(Salindex[i].OverTimeSal);
                            //                double CalOS = (ovrSalary * PubOverTime);
                            //                OTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
                            //            }
                            //        }
                            //        else { Otime = "00"; }
                            //        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                            //        if (DayOfOverTime != "")
                            //        {
                            //            char[] chr = { ':' };
                            //            string[] OTimeArry = DayOfOverTime.Split(chr);
                            //            string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
                            //            string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
                            //            int min1 = 0, min2 = 0;
                            //            int CalArrymin1 = Convert.ToInt32(getTimeMin1);
                            //            if (CalArrymin1 > 59)
                            //            {
                            //                double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
                            //                string AAAA = Convert.ToString(hrrr1.ToString("###0.00"));
                            //                char[] chr1 = { '.' };
                            //                string[] MinArry = AAAA.Split(chr1);
                            //                if (MinArry.Length > 1)
                            //                {
                            //                    min1 = Convert.ToInt32(MinArry[0]);
                            //                    min2 = Convert.ToInt32(MinArry[1]);
                            //                }
                            //                double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
                            //                string fin = CalMin1.ToString("###0");
                            //                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                            //                double dhrs = Convert.ToDouble(Add);
                            //                string Hours = dhrs.ToString("###0");
                            //                double CalcInteger = Convert.ToDouble(Hours + "." + fin);
                            //                if (CalcInteger > 1)
                            //                {
                            //                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
                            //                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);

                            //                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                            //                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                            //                }
                            //                else
                            //                {
                            //                    PubOverTime = Convert.ToDouble("0.000");
                            //                }
                            //            }
                            //            else
                            //            {
                            //                double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
                            //                string fin = CalMin1.ToString("###0");
                            //                int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                            //                double dhrs1 = Convert.ToDouble(Add);
                            //                string Hours1 = dhrs1.ToString("###0");
                            //                double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
                            //                if (CalcInteger > 0)
                            //                {
                            //                    double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
                            //                    double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);

                            //                    double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                            //                    PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                            //                }
                            //                else
                            //                {
                            //                    PubOverTime = Convert.ToDouble("0.000");
                            //                }
                            //                double ovrSalary = Convert.ToDouble(Salindex[i].OverTimeSal.ToString());
                            //                double CalOS = (ovrSalary * PubOverTime);
                            //                DayOTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
                            //            }
                            //        }
                            //        else
                            //        {
                            //            Otime = "0.00";
                            //        }
                            //        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                            //        FinalOvrtimeSal = Convert.ToDecimal(OTcalSal + DayOTcalSal);
                            //    }
                            //}

                            #endregion
                            // FinalOvrtimeSal = Convert.ToDecimal(TotalOverTime * HRSRate);
                            FinalOvrtimeSal = Convert.ToDecimal(FinalOvrtimeSal == 0 ? "0.000" : FinalOvrtimeSal.ToString("#######0.000"));
                            #region -==================Holiday Salary====================-
                            if (Salindex.Count > 0)
                            {
                                HoliTime = Salindex[0].HolidayTimings;
                            }
                            if (HoliTime != "")
                            {
                                char[] chr = { ':' };
                                string[] HoliTimeArry = HoliTime.Split(chr);
                                string getTimeHrs2 = HoliTimeArry.Length > 0 ? HoliTimeArry[0].ToString() : "0";
                                string getTimeMin2 = HoliTimeArry.Length > 0 ? HoliTimeArry[1].ToString() : "0";
                                // string getTimeSec = TimeArry[2].ToString();

                                int min3 = 0, min4 = 0;
                                int CalArrymin2 = Convert.ToInt32(getTimeMin2);
                                if (CalArrymin2 > 59)
                                {
                                    double hrrr2 = (Convert.ToDouble(CalArrymin2) / Convert.ToDouble(60));
                                    string AAAA = Convert.ToString(hrrr2.ToString("####0.000"));
                                    char[] chr1 = { '.' };
                                    string[] HoliMinArry = AAAA.Split(chr1);
                                    min3 = Convert.ToInt32(HoliMinArry[0]);
                                    min4 = Convert.ToInt32(HoliMinArry[1]);

                                    double HoliCalMin1 = (Convert.ToDouble(min4) * (0.16666666666666666666666666666667));
                                    string finHoli = HoliCalMin1.ToString("###0");
                                    int Add1 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
                                    double Holidhrs = Convert.ToDouble(Add1);
                                    string HoliHours = Holidhrs.ToString("###0");

                                    double HoliCalcInteger = Convert.ToDouble(HoliHours + "." + finHoli);
                                    if (HoliCalcInteger > 1)
                                    {
                                        double HoliSal1 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(HoliHours));
                                        double HoliSal2 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(finHoli) / 60);
                                        double HoliTotWeeklySalary = Convert.ToDouble(HoliSal1 + HoliSal2);
                                        PubHoliday = Convert.ToDouble(HoliTotWeeklySalary.ToString("######0.000"));
                                    }
                                    else
                                        PubHoliday = Convert.ToDouble("0.000");
                                }
                                else
                                {
                                    double HoliCalMin1 = (Convert.ToDouble(CalArrymin2) * (0.16666666666666666666666666666667));
                                    string Holifin = HoliCalMin1.ToString("###0");
                                    int Add3 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
                                    double Holidhrs1 = Convert.ToDouble(Add3);
                                    string HoliHours1 = Holidhrs1.ToString("###0");

                                    double CalcIntegerHoli = Convert.ToDouble(HoliHours1 + "." + Holifin);

                                    if (CalcIntegerHoli > 1)
                                    {
                                        double HoliSal3 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(HoliHours1));
                                        double HoliSal4 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(Holifin) / 60);

                                        double HoliTotWeeklySalary1 = Convert.ToDouble(HoliSal3 + HoliSal4);
                                        PubHoliday = Convert.ToDouble(HoliTotWeeklySalary1.ToString("######0.000"));

                                    }
                                    else
                                        PubHoliday = Convert.ToDouble("0.000");

                                }
                            }
                            else
                            {
                                HoliTime = "00";
                                PubHoliday = Convert.ToDouble("0.000");
                            }
                            FinalHolidaySal = Convert.ToDecimal(PubHoliday);
                            #endregion

                            DrawAmt = (index[i].DrawAmt.ToString() != "") ? Convert.ToDecimal(index[i].DrawAmt) : 0;

                        }

                        #region =============="Variable Amt bind coding"===============
                        decimal Advance = 0, Punishment = 0, Neglet = 0, Others = 0, Reward = 0, Incentives = 0;
                        var VariableIndex = dicSalHelper["EmpVariabledetails"].FindAll(x => x.CalcType == ViewType);
                        for (int j = 0; j < VariableIndex.Count; j++)
                        {
                            int UserId = VariableIndex[j].UserId;
                            if (EMPID == UserId)
                            {
                                int varid = VariableIndex[j].VariableID;
                                varAmt = Convert.ToDecimal(VariableIndex[j].MonthlyDeduction);
                                decimal varAmt1 = Convert.ToDecimal(VariableIndex[j].VariableAmount);
                                if (varid == 101) { Advance = varAmt; TotAmt += varAmt; }
                                if (varid == 102) { Punishment = varAmt; TotAmt += varAmt; }
                                if (varid == 103) { Neglet = varAmt; TotAmt += varAmt; }
                                if (varid == 104) { Reward = varAmt1; ADDTotAmt += varAmt1; }
                                if (varid == 105) { Incentives = varAmt1; ADDTotAmt += varAmt1; }
                                if (varid == 106) { Others = varAmt; TotAmt += varAmt; }
                                //break;
                            }
                        }

                        #endregion

                        decimal Netsalary = 0, TotBaseOver = 0;

                        Netsalary = Convert.ToDecimal(((baseSal + FinalEmpWorkSal + FinalOvrtimeSal + FinalHolidaySal + ADDTotAmt) - (TotAmt + DrawAmt + FinalLaten)).ToString("#######0.000"));
                        TotBaseOver = Convert.ToDecimal((FinalEmpWorkSal + FinalOvrtimeSal + FinalHolidaySal + ADDTotAmt).ToString("######0.000"));
                        if (index.Count > 0)
                        {
                            decimal TotSal = 0;
                            for (int n = 0; n < index.Count; n++)
                            {
                                if (index != null)
                                { TotSal += Convert.ToDecimal(index[n].TotalSales); }
                                else { TotSal += 0; }
                            }
                            ObjSalPay.ObjEmployeeObject.TotalSaleText = TotSal.ToString("######0.000");
                        }
                        string saltype = string.Empty;
                        if (index[i].CalcType.ToString() == "0") saltype = "Monthly";
                        if (index[i].CalcType.ToString() == "1") saltype = "Weekly";
                        if (index[i].CalcType.ToString() == "2") saltype = "Hourly";
                        if (index[i].CalcType.ToString() == "3") saltype = "Percentage";
                        listSalHelper.Add(new EmployeeObjectClass
                        {
                            Select = false,
                            EmpId = index[i].UserId,
                            EmpName = index[i].FirstName,
                            CalcType = index[i].CalcType,
                            saltype = saltype,
                            BasicSalary = Convert.ToDecimal(index[i].BasicSalary.ToString("######0.000")),
                            OverTimeSal = Convert.ToDecimal(index[i].OverTimeSal.ToString("######0.000")),
                            HolidaySal = Convert.ToDecimal(index[i].HolidaySal.ToString("######0.000")),
                            SalaryForPerDay = Convert.ToDecimal(OneDayRate.ToString("######0.000")),
                            SalaryForPerHour = Convert.ToDecimal(HRSRate.ToString("######0.000")),
                            EmpSalary = Convert.ToDecimal(FinalEmpWorkSal.ToString("######0.000")),
                            Average = Convert.ToDecimal(Avg.ToString("######0.000")),
                            OverTimings = Otime,
                            EmpOverSalary = Convert.ToDecimal(FinalOvrtimeSal.ToString("######0.000")),
                            HolidayOverTime = HoliTime,
                            EmpHoliSalary = Convert.ToDecimal(PubHoliday.ToString("######0.000")),
                            DrawAmt = Convert.ToDecimal(DrawAmt.ToString("######0.000")),
                            Advance = Convert.ToDecimal(Advance.ToString("######0.000")),
                            Punishment = Convert.ToDecimal(Punishment.ToString("######0.000")),
                            Neglect = Convert.ToDecimal(Neglet.ToString("######0.000")),
                            Reward = Convert.ToDecimal(Reward.ToString("######0.000")),
                            Incentive = Convert.ToDecimal(Incentives.ToString("######0.000")),
                            Others = Convert.ToDecimal(Others.ToString("######0.000")),
                            WorkingDays = TotalDays,
                            WorkedDays = EmpPresentDays,
                            LatencyAmt = Convert.ToDecimal(FinalLaten.ToString("######0.000")),
                            NetSalary = Convert.ToDecimal(Netsalary.ToString("######0.000")),
                        });
                        TotAmt = 0;
                        ADDTotAmt = 0;
                    }
                }
                CalculateTotal();
            }
            return listSalHelper;
        }
        #endregion

        #region FillDatasInGridViewByPERCENTAGE()
        public List<EmployeeObjectClass> FillDatasInGridViewByPERCENTAGE(int ViewType)
        {
            int EMPID;
            double Perc = 0;
            decimal BaseSalaryInNetAmt = 0, PercentageOfSalary = 0;
            decimal baseSal = 0, OvrtimeSal = 0;
            decimal Avg = 0;
            string Otime = string.Empty; string HoliTime = string.Empty;
            int TotalDays = 0, EmpPresentDays = 0;
            if (ObjSalPay.ObjEmployeeObject.chkAllEmployee != true)
            {
                listSalHelper.Clear();
            }
            if (dicSalHelper != null)
            {
                var index = dicSalHelper["EmpBasicdetails"].FindAll(x => x.CalcType == ViewType);
                for (int i = 0; i < index.Count; i++)
                {
                    int system = index[i].CalcType;

                    //-----------------------------------------
                    if (system == ViewType)
                    {
                        EMPID = index[i].UserId;
                        decimal Base = index[i].BasicSalary;
                        decimal OSal = index[i].OverTimeSal;
                        decimal HSal = index[i].HolidaySal;
                        baseSal = Convert.ToDecimal(Base);
                        OvrtimeSal = Convert.ToDecimal(OSal);
                        string perSal = index[i].PercSales.ToString();
                        Perc = Convert.ToDouble(perSal);
                        string hrsinday = index[i].EmpWorkHrs.ToString();
                        int CalHRS = 0;
                        if (hrsinday != "")
                        {
                            string[] ssss = hrsinday.Split(':');
                            CalHRS = Convert.ToInt32((Convert.ToInt32(ssss[0])) + (Convert.ToInt32(ssss[1]) * (0.16666666666666666666666666666667)));
                        }
                        int GetWeekend, MonthHolidays = 0;
                        if (dicSalHelper["EmpWeekOffDetails"] != null)
                        {
                            var WeekOffindex = dicSalHelper["EmpWeekOffDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
                            if (WeekOffindex.Count > 0)
                            {
                                GetWeekend = WeekOffindex[0].WeekEnd;
                                if (GetWeekend == 1)
                                    MonthHolidays = WeekOffindex[0].Suncount;
                                else if (GetWeekend == 2)
                                    MonthHolidays = WeekOffindex[0].Moncount;
                                else if (GetWeekend == 2)
                                    MonthHolidays = WeekOffindex[0].Tuescount;
                                else if (GetWeekend == 2)
                                    MonthHolidays = WeekOffindex[0].Wedcount;
                                else if (GetWeekend == 2)
                                    MonthHolidays = WeekOffindex[0].Thurscount;
                                else if (GetWeekend == 2)
                                    MonthHolidays = WeekOffindex[0].Fricount;
                                else
                                    MonthHolidays = WeekOffindex[0].Satcount;
                            }
                            else
                            {
                                GetWeekend = 0;
                                MonthHolidays = 0;
                            }
                        }
                        int ttday = 30;
                        int holiday = Convert.ToInt32(MonthHolidays);
                        int workingday = (ttday - holiday);
                        int worHRSperMon = (CalHRS * workingday);
                        decimal HRSRate = (baseSal / worHRSperMon);
                        decimal OneDayRate = (CalHRS * Convert.ToDecimal(HRSRate.ToString("########0.000")));

                        decimal perdayBase = (baseSal / 30);
                        if (dicSalHelper["EmpSalDetails"] != null)
                        {
                            var Salindex = dicSalHelper["EmpSalDetails"].FindAll(x => x.CalcType == ViewType && x.UserId == EMPID);
                            string TotalWorkedHRS = string.Empty;
                            if (Salindex.Count > 0)
                            {
                                string getdays = Salindex[0].WorkedDays.ToString();
                                BaseSalaryInNetAmt = Convert.ToDecimal((perdayBase * int.Parse(getdays)));
                                decimal TotalSales = (index[i].TotalSales.ToString() != "") ? Convert.ToDecimal(index[i].TotalSales.ToString()) : 0;
                                PercentageOfSalary = (Convert.ToDecimal(Convert.ToDouble(TotalSales) * Perc) / 100);

                                TotalWorkedHRS = Salindex[0].WorkTimings;
                                TotalDays = Salindex[0].WorkingDays;
                                EmpPresentDays = Salindex[0].WorkedDays;
                            }
                            double hr = 0, mi = 0; decimal ttempHRS = 0;
                            decimal EmpWorkSal = 0;
                            int miHH = 0;
                            if (TotalWorkedHRS != "")
                            {
                                string[] hrsMin = TotalWorkedHRS.Split(':');
                                hr = Convert.ToInt32(hrsMin[0]);

                                if (Convert.ToInt32(hrsMin[1]) > 60)
                                {
                                    decimal vval = (Convert.ToDecimal(hrsMin[1]) / 60);
                                    string[] Minshh = vval.ToString().Split('.');
                                    miHH = Convert.ToInt32(Minshh[0]);
                                    int salHrs = 0;
                                    if (Minshh.Length > 1)
                                    {
                                        salHrs = Minshh[1].Length > 3 ? Convert.ToInt32(Minshh[1].Substring(0, 2)) : Convert.ToInt32(Minshh[1]);
                                    }
                                    mi = Convert.ToInt32((Convert.ToInt32(salHrs.ToString("###0")) * (0.16666666666666666666666666666667)));
                                }
                                else
                                {
                                    mi = Convert.ToInt32((Convert.ToInt32(hrsMin[1]) * (0.16666666666666666666666666666667)));
                                }
                                string strcon = (Convert.ToString(hr + miHH) + "." + Convert.ToString(mi));
                                ttempHRS = Convert.ToDecimal(strcon);
                                EmpWorkSal = (Convert.ToDecimal(ttempHRS) * Convert.ToDecimal(HRSRate.ToString("######0.000")));
                            }
                            else
                                EmpWorkSal = Convert.ToDecimal("0.000");

                            int empNoofSal = 0;
                            decimal empTtSalAmt = 0, empPercSal = 0;

                            var PercIndex = dicSalHelper["EmpPercentDetails"].FindAll(x => x.CalcType == ObjSalPay.ObjEmployeeObject.CalcType && x.UserId == EMPID);
                            if (PercIndex.Count > 0)
                            {
                                empNoofSal = Convert.ToInt32(PercIndex[0].TotalSales.ToString());
                                empTtSalAmt = Convert.ToDecimal(PercIndex[0].Netamount.ToString());
                                empPercSal = Convert.ToDecimal(PercIndex[0].PercSales.ToString());
                            }
                            decimal calc = (empPercSal > 0) ? ((empTtSalAmt * empPercSal) / 100 + baseSal) : baseSal;
                            FinalEmpWorkSal = calc;

                            string HRS = string.Empty; string MIN = string.Empty;
                            if (Salindex.Count > 0)
                            {
                                HRS = Salindex[0].LatencyHours.ToString();
                                MIN = Salindex[0].LatencyMin.ToString();
                            }

                            int LatHRS, LatMIN;
                            if (HRS != "") { LatHRS = Convert.ToInt32(HRS); } else { LatHRS = 0; }
                            if (MIN != "") { LatMIN = Convert.ToInt32(MIN); } else { LatMIN = 0; }

                            //=====================================

                            double SalHRS = (LatHRS * Convert.ToDouble(HRSRate));
                            double calMin; double SalMIN = 0;
                            if (LatMIN > 60)
                            {
                                calMin = (LatMIN / 60);
                                SalMIN = (calMin * Convert.ToInt32(HRSRate));
                            }
                            else
                            {
                                if (LatMIN != 0)
                                { SalMIN = (1 * Convert.ToInt32(HRSRate)); }
                                else { SalMIN = 0; }
                            }
                            double TotSalary = (SalHRS + SalMIN);

                            FinalLaten = 0;
                            //if (GeneralOptionSetting.FlagCutLatencyAutomatically == "Y")
                            //{
                            //    FinalLaten = Convert.ToDecimal(TotSalary.ToString("######0.000"));
                            //}
                            //else
                            //{
                            //    FinalLaten = Convert.ToDecimal(0);
                            //}

                            //-------------------------------"Average calculation"
                            decimal avgall = Convert.ToDecimal((workingday * 6));
                            decimal avgper = Convert.ToDecimal((ttempHRS * 6));
                            decimal aaa = Convert.ToDecimal((avgper / avgall));
                            Avg = aaa;
                            //-----------------------------
                            if (index[i].TotalSales.ToString() != string.Empty)
                            {

                                decimal TotSal = Convert.ToDecimal(index[i].TotalSales);
                                //-----------------------------------------------Txt_TotalSales.Text = TotSal.ToString("#######0.000");---------------------------------//
                            }
                            else
                            {
                                //-----------------------------------------------Txt_TotalSales.Text = TotSal.ToString("#######0.000");---------------------------------//
                            }

                            //==============================================

                            #region -=============OverTime/DayOfOverTime Salary=================-
                            if (Salindex.Count > 0)
                            {
                                if (Salindex[0].OverTimings != null)
                                {

                                    Otime = Salindex[0].OverTimings.ToString();
                                    string DayOfOverTime = Salindex[0].DayofOverTime.ToString();
                                    double DayOTcalSal = 0, OTcalSal = 0;
                                    if (Otime != "")
                                    {
                                        char[] chr = { ':' };
                                        string[] OTimeArry = Otime.Split(chr);
                                        string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
                                        string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
                                        int min1 = 0, min2 = 0;
                                        int CalArrymin1 = Convert.ToInt32(getTimeMin1);
                                        if (CalArrymin1 > 59)
                                        {
                                            double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
                                            string AAAA = Convert.ToString(hrrr1.ToString("#####0.000"));
                                            char[] chr1 = { '.' };
                                            string[] MinArry = AAAA.Split(chr1);
                                            min1 = Convert.ToInt32(MinArry[0]);
                                            min2 = Convert.ToInt32(MinArry[1]);

                                            double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs = Convert.ToDouble(Add);
                                            string Hours = dhrs.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours + "." + fin);
                                            if (CalcInteger > 1)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);
                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else { PubOverTime = Convert.ToDouble("0.000"); }
                                        }
                                        else
                                        {
                                            double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs1 = Convert.ToDouble(Add);
                                            string Hours1 = dhrs1.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
                                            if (CalcInteger > 0)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);
                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else
                                            {
                                                PubOverTime = Convert.ToDouble("0.000");
                                            }
                                            double ovrSalary = Convert.ToDouble(Salindex[i].OverTimeSal);
                                            double CalOS = (ovrSalary * PubOverTime);
                                            OTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
                                        }
                                    }
                                    else { Otime = "00"; }
                                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    if (DayOfOverTime != "")
                                    {
                                        char[] chr = { ':' };
                                        string[] OTimeArry = DayOfOverTime.Split(chr);
                                        string getTimeHrs1 = OTimeArry.Length > 0 ? OTimeArry[0].ToString() : "0";
                                        string getTimeMin1 = OTimeArry.Length > 1 ? OTimeArry[1].ToString() : "0";
                                        int min1 = 0, min2 = 0;
                                        int CalArrymin1 = Convert.ToInt32(getTimeMin1);
                                        if (CalArrymin1 > 59)
                                        {
                                            double hrrr1 = (Convert.ToDouble(CalArrymin1) / Convert.ToDouble(60));
                                            string AAAA = Convert.ToString(hrrr1.ToString("#####0.000"));
                                            char[] chr1 = { '.' };
                                            string[] MinArry = AAAA.Split(chr1);
                                            if (MinArry.Length > 1)
                                            {
                                                min1 = Convert.ToInt32(MinArry[0]);
                                                min2 = Convert.ToInt32(MinArry[1]);
                                            }
                                            double CalMin1 = (Convert.ToDouble(min2) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs = Convert.ToDouble(Add);
                                            string Hours = dhrs.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours + "." + fin);
                                            if (CalcInteger > 1)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(Hours));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours) * Convert.ToDouble(fin) / 60);

                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else
                                            {
                                                PubOverTime = Convert.ToDouble("0.000");
                                            }
                                        }
                                        else
                                        {
                                            double CalMin1 = (Convert.ToDouble(CalArrymin1) * (0.16666666666666666666666666666667));
                                            string fin = CalMin1.ToString("###0");
                                            int Add = Convert.ToInt32(getTimeHrs1) + Convert.ToInt32(min1);
                                            double dhrs1 = Convert.ToDouble(Add);
                                            string Hours1 = dhrs1.ToString("###0");
                                            double CalcInteger = Convert.ToDouble(Hours1 + "." + fin);
                                            if (CalcInteger > 0)
                                            {
                                                double Sal1 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(Hours1));
                                                double Sal2 = Convert.ToDouble(Convert.ToDouble(Hours1) * Convert.ToDouble(fin) / 60);

                                                double TotWeeklySalary = Convert.ToDouble(Sal1 + Sal2);
                                                PubOverTime = Convert.ToDouble(TotWeeklySalary.ToString("######0.000"));
                                            }
                                            else
                                            {
                                                PubOverTime = Convert.ToDouble("0.000");
                                            }
                                            double ovrSalary = Convert.ToDouble(Salindex[i].OverTimeSal.ToString());
                                            double CalOS = (ovrSalary * PubOverTime);
                                            DayOTcalSal = Convert.ToDouble(CalOS.ToString("######0.000"));
                                        }
                                    }
                                    else
                                    {
                                        Otime = "0.00";
                                    }
                                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    FinalOvrtimeSal = Convert.ToDecimal(OTcalSal + DayOTcalSal);
                                }
                            }
                            #endregion
                            #region -==================Holiday Salary====================-
                            if (Salindex.Count > 0)
                            {
                                HoliTime = Salindex[0].HolidayTimings;
                            }
                            if (HoliTime != "")
                            {
                                char[] chr = { ':' };
                                string[] HoliTimeArry = HoliTime.Split(chr);
                                string getTimeHrs2 = HoliTimeArry.Length > 0 ? HoliTimeArry[0].ToString() : "0";
                                string getTimeMin2 = HoliTimeArry.Length > 0 ? HoliTimeArry[1].ToString() : "0";
                                // string getTimeSec = TimeArry[2].ToString();

                                int min3 = 0, min4 = 0;
                                int CalArrymin2 = Convert.ToInt32(getTimeMin2);
                                if (CalArrymin2 > 59)
                                {
                                    double hrrr2 = (Convert.ToDouble(CalArrymin2) / Convert.ToDouble(60));
                                    string AAAA = Convert.ToString(hrrr2.ToString("####0.000"));
                                    char[] chr1 = { '.' };
                                    string[] HoliMinArry = AAAA.Split(chr1);
                                    min3 = Convert.ToInt32(HoliMinArry[0]);
                                    min4 = Convert.ToInt32(HoliMinArry[1]);

                                    double HoliCalMin1 = (Convert.ToDouble(min4) * (0.16666666666666666666666666666667));
                                    string finHoli = HoliCalMin1.ToString("###0");
                                    int Add1 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
                                    double Holidhrs = Convert.ToDouble(Add1);
                                    string HoliHours = Holidhrs.ToString("###0");

                                    double HoliCalcInteger = Convert.ToDouble(HoliHours + "." + finHoli);
                                    if (HoliCalcInteger > 1)
                                    {
                                        double HoliSal1 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(HoliHours));
                                        double HoliSal2 = Convert.ToDouble(Convert.ToDouble(HoliHours) * Convert.ToDouble(finHoli) / 60);
                                        double HoliTotWeeklySalary = Convert.ToDouble(HoliSal1 + HoliSal2);
                                        PubHoliday = Convert.ToDouble(HoliTotWeeklySalary.ToString("######0.000"));
                                    }
                                    else
                                        PubHoliday = Convert.ToDouble("0.000");
                                }
                                else
                                {
                                    double HoliCalMin1 = (Convert.ToDouble(CalArrymin2) * (0.16666666666666666666666666666667));
                                    string Holifin = HoliCalMin1.ToString("###0");
                                    int Add3 = Convert.ToInt32(getTimeHrs2) + Convert.ToInt32(min3);
                                    double Holidhrs1 = Convert.ToDouble(Add3);
                                    string HoliHours1 = Holidhrs1.ToString("###0");

                                    double CalcIntegerHoli = Convert.ToDouble(HoliHours1 + "." + Holifin);

                                    if (CalcIntegerHoli > 1)
                                    {
                                        double HoliSal3 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(HoliHours1));
                                        double HoliSal4 = Convert.ToDouble(Convert.ToDouble(HoliHours1) * Convert.ToDouble(Holifin) / 60);

                                        double HoliTotWeeklySalary1 = Convert.ToDouble(HoliSal3 + HoliSal4);
                                        PubHoliday = Convert.ToDouble(HoliTotWeeklySalary1.ToString("######0.000"));

                                    }
                                    else
                                        PubHoliday = Convert.ToDouble("0.000");
                                }
                            }
                            else
                            {
                                HoliTime = "00";
                                PubHoliday = Convert.ToDouble("0.000");
                            }
                            FinalHolidaySal = Convert.ToDecimal(PubHoliday);
                            #endregion

                            DrawAmt = (index[i].DrawAmt.ToString() != "") ? Convert.ToDecimal(index[i].DrawAmt) : 0;

                        }

                        #region =============="Variable Amt bind coding"===============
                        decimal Advance = 0, Punishment = 0, Neglet = 0, Others = 0, Reward = 0, Incentives = 0;
                        var VariableIndex = dicSalHelper["EmpVariabledetails"].FindAll(x => x.CalcType == ViewType);
                        for (int j = 0; j < VariableIndex.Count; j++)
                        {
                            int UserId = VariableIndex[j].UserId;
                            if (EMPID == UserId)
                            {
                                int varid = VariableIndex[j].VariableID;
                                varAmt = Convert.ToDecimal(VariableIndex[j].MonthlyDeduction);
                                decimal varAmt1 = Convert.ToDecimal(VariableIndex[j].VariableAmount);
                                if (varid == 101) { Advance = varAmt; TotAmt += varAmt; }
                                if (varid == 102) { Punishment = varAmt; TotAmt += varAmt; }
                                if (varid == 103) { Neglet = varAmt; TotAmt += varAmt; }
                                if (varid == 104) { Reward = varAmt1; ADDTotAmt += varAmt1; }
                                if (varid == 105) { Incentives = varAmt1; ADDTotAmt += varAmt1; }
                                if (varid == 106) { Others = varAmt; TotAmt += varAmt; }
                                //break;
                            }
                        }

                        #endregion

                        decimal Netsalary = 0, TotBaseOver = 0;

                        Netsalary = Convert.ToDecimal(((BaseSalaryInNetAmt + PercentageOfSalary + ADDTotAmt) - (TotAmt + DrawAmt)).ToString("#######0.000"));
                        TotBaseOver = Convert.ToDecimal((BaseSalaryInNetAmt + PercentageOfSalary + FinalOvrtimeSal + FinalHolidaySal + ADDTotAmt).ToString("######0.000"));


                        if (index.Count > 0)
                        {
                            decimal TotSal = 0;
                            for (int n = 0; n < index.Count; n++)
                            {
                                if (index != null)
                                { TotSal += Convert.ToDecimal(index[n].TotalSales); }
                                else { TotSal += 0; }
                            }
                            ObjSalPay.ObjEmployeeObject.TotalSaleText = TotSal.ToString("######0.000");
                        }
                        string saltype = string.Empty;
                        if (index[i].CalcType.ToString() == "0") saltype = "Monthly";
                        if (index[i].CalcType.ToString() == "1") saltype = "Weekly";
                        if (index[i].CalcType.ToString() == "2") saltype = "Hourly";
                        if (index[i].CalcType.ToString() == "3") saltype = "Percentage";
                        listSalHelper.Add(new EmployeeObjectClass
                        {
                            Select = false,
                            EmpId = index[i].UserId,
                            EmpName = index[i].FirstName,
                            CalcType = index[i].CalcType,
                            saltype = saltype,
                            BasicSalary = Convert.ToDecimal(index[i].BasicSalary.ToString("######0.000")),
                            OverTimeSal = Convert.ToDecimal(index[i].OverTimeSal.ToString("######0.000")),
                            HolidaySal = Convert.ToDecimal(index[i].HolidaySal.ToString("######0.000")),
                            SalaryForPerDay = Convert.ToDecimal(OneDayRate.ToString("######0.000")),
                            SalaryForPerHour = Convert.ToDecimal(HRSRate.ToString("######0.000")),
                            EmpSalary = Convert.ToDecimal(FinalEmpWorkSal.ToString("######0.000")),
                            Average = Convert.ToDecimal(Avg.ToString("######0.000")),
                            OverTimings = Otime,
                            EmpOverSalary = Convert.ToDecimal(FinalOvrtimeSal.ToString("######0.000")),
                            HolidayOverTime = HoliTime,
                            EmpHoliSalary = Convert.ToDecimal(PubHoliday.ToString("######0.000")),
                            DrawAmt = Convert.ToDecimal(DrawAmt.ToString("######0.000")),
                            Advance = Convert.ToDecimal(Advance.ToString("######0.000")),
                            Punishment = Convert.ToDecimal(Punishment.ToString("######0.000")),
                            Neglect = Convert.ToDecimal(Neglet.ToString("######0.000")),
                            Reward = Convert.ToDecimal(Reward.ToString("######0.000")),
                            Incentive = Convert.ToDecimal(Incentives.ToString("######0.000")),
                            Others = Convert.ToDecimal(Others.ToString("######0.000")),
                            WorkingDays = TotalDays,
                            WorkedDays = EmpPresentDays,
                            LatencyAmt = Convert.ToDecimal(FinalLaten.ToString("######0.000")),
                            NetSalary = Convert.ToDecimal(Netsalary.ToString("######0.000")),
                        });
                        TotAmt = 0;
                        ADDTotAmt = 0;
                    }
                }
                CalculateTotal();
            }
            return listSalHelper;
        }
        #endregion

        public int Save_PaySalaryDetails()
        {
            //int i = ObjSalPay.Save_PaySalaryDetails();
            //return i;
            return ObjSalPay.Save_PaySalaryDetails();
        }
        public int Undo_SalaryPaymentDetails()
        {
            //int i = ObjSalPay.Undo_SalaryPaymentDetails();
            //return i;
            return ObjSalPay.Undo_SalaryPaymentDetails();
        }
        public void SaveSpendings()
        {
            ObjSalPay.SaveSpendings();
        }
        private void CalculateTotal()
        {
            DataTable dt = new DataTable();
            // dt = (DataTable)Dgv_SalaryPaymentList.DataSource;
            decimal dec = 0;
            if (listSalHelper != null)
            {
                if (listSalHelper.Count > 0)
                {
                    for (int j = 0; j < listSalHelper.Count; j++)
                    {
                        dec += (listSalHelper[j].NetSalary.ToString() != "") ? Convert.ToDecimal(listSalHelper[j].NetSalary.ToString()) : 0;
                    }
                    string TotAmt = dec.ToString("######0.000");
                    ObjSalPay.ObjEmployeeObject.TotalSalaryText = string.Empty;
                    ObjSalPay.ObjEmployeeObject.TotalSalaryText = TotAmt;
                }
            }
        }
        public bool UndoPaymentHelper(List<EmployeeObjectClass> listSalarygrid)
        {
            var index = listSalarygrid.FindAll(x => x.Select == true);
            int rescount = 0; bool result = false;
            if (index != null)
            {
                if (index.Count > 0)
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        ObjSalPay.ObjEmployeeObject.UserId = index[i].EmpId;
                        int res = Undo_SalaryPaymentDetails();
                        if (res > 0)
                        {
                            #region *---------Undo Variable Amount-----------*
                            // ObjDicSalary["EmpVariabledetails"].ToList();
                            var Variableindex = dicSalHelper["EmpVariabledetails"].FindAll(x => x.UserId == ObjSalPay.ObjEmployeeObject.UserId);
                            for (int j = 0; j < Variableindex.Count; j++)
                            {
                                if (Variableindex[j].MonthlyDeduction != 0)
                                {
                                    int varempid = Variableindex[j].EmployeeVariablesID;
                                    ObjSalPay.ObjEmployeeObject.EmployeeVariablesID = varempid;
                                    ObjSalPay.ObjEmployeeObject.GroupID = Variableindex[j].GroupID;
                                    ObjSalPay.ObjEmployeeObject.GroupName = Variableindex[j].GroupName;
                                    ObjSalPay.ObjEmployeeObject.EffectiveDate = DateTime.Now;
                                    ObjSalPay.ObjEmployeeObject.VariableAmount = Variableindex[j].VariableAmount;
                                    ObjSalPay.ObjEmployeeObject.Remarks = "Payment Undo";
                                    ObjSalPay.ObjEmployeeObject.MonthlyDeduction = Variableindex[j].MonthlyDeduction;
                                    ObjSalPay.ObjEmployeeObject.Status = Variableindex[j].Status;
                                    ObjSalPay.ObjEmployeeObject.Remove = Variableindex[j].Remove;
                                    ObjSalPay.ObjEmployeeObject.NoOfInstallment = Variableindex[j].NoOfInstallment;
                                    ObjSalPay.ObjEmployeeObject.StartMonthDeduction = Variableindex[j].StartMonthDeduction;
                                    ObjSalPayBALClass.UndoSalaryVariables();
                                }
                            }
                            #endregion

                            #region *----------Undo Drawing Amount-----------*
                            for (int k = 0; k < index.Count; k++)
                            {
                                if (index[k].DrawAmt != 0)
                                {
                                    ObjSalPay.ObjEmployeeObject.EmployeeVariablesID = index[k].EmployeeVariablesID;
                                    ObjSalPay.ObjEmployeeObject.EmpId = index[k].UserId;
                                    ObjSalPay.ObjEmployeeObject.EffectiveDate = DateTime.Now;
                                    ObjSalPay.ObjEmployeeObject.DrawAmt = index[k].DrawAmt;
                                    ObjSalPay.ObjEmployeeObject.Notes = "Payment Update";
                                    ObjSalPay.ObjEmployeeObject.StartMonthDeduction = index[k].StartMonthDeduction;
                                    ObjSalPay.ObjEmployeeObject.Status = 1;
                                    ObjSalPay.ObjEmployeeObject.Remove = false;
                                    ObjSalPay.ObjEmployeeObject.Description = string.Empty;
                                    ObjSalPay.ObjEmployeeObject.NoOfInstallment = 1;
                                    ObjSalPayBALClass.UndoSalaryDrawings();
                                }
                            }
                            #endregion
                            rescount++;
                        }
                        else
                        {
                            GeneralFunction.Information("NoUndoSalaryPayment", "Salary Payment");
                        }

                    }
                    if (rescount > 0)
                    {
                        GeneralFunction.Information("UndoSalarySuccess", "Salary Payment");
                        return result = true;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Update), "Salary Payment", "MTB_USER_SALARY_PAYMENT", "Modify salary payment details", Convert.ToInt32(InvoiceAction.No));
                    }
                }
            }
            return result;
        }


        internal void Print(DataTable DTable)
        {
            Rpt_SalaryPaymentDetail summery = new Rpt_SalaryPaymentDetail();
            ReportsView rptView = new ReportsView();
            rptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("SalaryPayment");
            Get_ReportTotalValues(DTable);
            //summery.SetDataSource(DTable);
            rptView.HTable.Clear();
            //summery.Refresh();
            DTable.TableName = "SalaryPayment";
            rptView.Report_Table = DTable;

            rptView.RptDoc = summery;
            rptView.HTable.Add("BasicSalary", TBaseSalary);
            rptView.HTable.Add("EmpOverSalary", TOverTime);
            rptView.HTable.Add("Advance", TAdvances);
            rptView.HTable.Add("Punishment", TPunishment);
            rptView.HTable.Add("Neglect", TNeglet);
            rptView.HTable.Add("Reward", TReward);
            rptView.HTable.Add("Incentive", TIncentives);
            rptView.HTable.Add("Others", TOthers);
            rptView.HTable.Add("DrawAmt", TAmount);
            rptView.HTable.Add("NetSalary", TNetSalary);
            rptView.LoadEvent();
            rptView.ShowDialog();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "SalaryPayment", "RECEIPT", "Print salary payment details", Convert.ToInt32(InvoiceAction.No));
        }

        private void Get_ReportTotalValues(DataTable dtab)
        {
            try
            {
                if (dtab != null)
                {
                    if (dtab.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtab.Rows.Count; i++)
                        {
                            TBaseSalary += Convert.ToDecimal(dtab.Rows[i]["BasicSalary"]);
                            TOverTime += Convert.ToDecimal(dtab.Rows[i]["EmpOverSalary"]);
                            TAdvances += Convert.ToDecimal(dtab.Rows[i]["Advance"]);
                            TPunishment += Convert.ToDecimal(dtab.Rows[i]["Punishment"]);
                            TReward += Convert.ToDecimal(dtab.Rows[i]["Reward"]);
                            TIncentives += Convert.ToDecimal(dtab.Rows[i]["Incentive"]);
                            TOthers += Convert.ToDecimal(dtab.Rows[i]["Others"]);
                            TAmount += Convert.ToDecimal(dtab.Rows[i]["DrawAmt"]);
                            TNetSalary += Convert.ToDecimal(dtab.Rows[i]["NetSalary"]);
                            TNeglet += Convert.ToDecimal(dtab.Rows[i]["Neglect"]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Print", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public void DisposeListObject()
        {
            dicSalHelper = null;
            listSalHelper = null;
            ObjSalPayBALClass = null;      
        }
    }
}
