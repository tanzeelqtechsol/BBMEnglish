using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using CommonHelper;
using BumedianBM.ViewHelper;


namespace BumedianBM.ArabicView
{
    public partial class TipOfDay : Form,IDisposable
    {
        #region "Variables"
        TipOfDayHelper objTipHelper;


        #endregion

        #region "Constructor"

        public TipOfDay()
        {
            InitializeComponent();
            objTipHelper = new TipOfDayHelper();
            Setlanguage();
        }

        private void Setlanguage()
        {
            this.Text = Additional_Barcode.GetValueByResourceKey(this.Tag.ToString());
            btnPrevTip.Text = Additional_Barcode.GetValueByResourceKey("PrevTip");
            btnNextTip.Text = Additional_Barcode.GetValueByResourceKey("NextTip");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("TipClose");
            chkShowTip.Text = Additional_Barcode.GetValueByResourceKey("ShowTipOnStartUp");
        }

        #endregion

        #region "Events"

        #region "Button Click Events"

        private void Btn_NextTip_Click(object sender, EventArgs e)
        {

            try
            {
                if (GeneralFunction.TipsCount + 1 < GeneralFunction.lstTips.Count)
                {
                    GeneralFunction.TipsCount += 1;
                    string[] str= objTipHelper.ShowTips();
                    RTxt_Tip.Lines = str;
                    btnNextTip.Enabled = GeneralFunction.TipsCount != GeneralFunction.lstTips.Count - 1;
                    btnPrevTip.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Btn_PrevTip_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunction.TipsCount - 1 >= 0 && GeneralFunction.TipsCount - 1 < GeneralFunction.lstTips.Count)
                {
                    GeneralFunction.TipsCount -= 1;
                    string[] str = objTipHelper.ShowTips();
                    RTxt_Tip.Lines = str;
                    btnPrevTip.Enabled = GeneralFunction.TipsCount != 0;
                    btnNextTip.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                //ObjProp.FlagShowTipDayWhenStart = Chk_ShowTip.Checked ? "Y" : "N";
                //ObjProp.OptionShowTipDayWhenStart = "Chk_ShowTipDayWhenStart";
                //ObjDal.UpdateOptionSetting(ObjProp.OptionShowTipDayWhenStart, ObjProp.FlagShowTipDayWhenStart);
                this.Close();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region "Form Load Event"

        private void TipOfDay_Load(object sender, EventArgs e)
        {
            try
            {
                RTxt_Tip.Lines = objTipHelper.LoadTipOfDay();
                
                //string filepath = System.Windows.Forms.Application.StartupPath + "\\Tips.xls";
                //string strCommand = "select * from [sheet1$]";
                //DataTable dt = new DataTable("Tips");
                //using (OleDbConnection con = new OleDbConnection(string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=Excel 8.0;", filepath)))
                //{
                //    OleDbDataAdapter daAdapter = new OleDbDataAdapter(strCommand, con);
                    
                //    daAdapter.FillSchema(dt, SchemaType.Source);
                //    daAdapter.Fill(dt);
                //    con.Close();
                //}
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    foreach (DataRow oRow in dt.Rows)
                //    {
                //        string item = string.Empty;
                //        if (oRow[0].ToString() != string.Empty)
                //        {
                //            lst.Add(oRow[0].ToString());
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
            }
            
        }

        #endregion

        #endregion

        #region Methods

        #region "Public Methods"

        #endregion

        #endregion

    }
}