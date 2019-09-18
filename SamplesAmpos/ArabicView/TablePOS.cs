using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using CommonHelper;
namespace BumedianBM.ArabicView
{
    public partial class TablePOS : Form,IDisposable
    {

        #region Declaration
        PosShortcutHelper objPosShortcutHelper;
        #endregion

        #region Constructor
        public TablePOS()
        {
            InitializeComponent();
            objPosShortcutHelper = new PosShortcutHelper();
            this.Text = Additional_Barcode.GetValueByResourceKey("Tables");
            tabTable1.Text = Additional_Barcode.GetValueByResourceKey("TabTable1");
            tabTable2.Text = Additional_Barcode.GetValueByResourceKey("TabTable2");
        }
        #endregion

        #region Events

        #region Form Load
        private void TablePOS_Load(object sender, EventArgs e)
        {
            try
            {
                BindDetailsToButton();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "TablePOS_Load");
            }
        }
        #endregion

        #region ButtonClick Events
        private void BtnShortcuts_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralFunction.IsTableSelected = true;
                Control ctr = (Button)sender;
                string btnshortcut = ctr.Name.Replace("Btn", "").Trim();
                GeneralFunction.TableShortCut = Convert.ToInt16(btnshortcut);
                ctr.ForeColor = Color.DarkRed;
                this.Close();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "BtnShortcuts_Click");
            }
        }
        #endregion


        #endregion

        #region Methods

        #region BindDetailsToButton
        private void BindDetailsToButton()
        {
            Control.ControlCollection ctr = this.Controls;

            objPosShortcutHelper.GetTableDetailsHelper();
            for (int i = 0; i < objPosShortcutHelper.lstTableDetails.Count; i++)
            {
                Control[] cn;
                string str = "Btn" + objPosShortcutHelper.lstTableDetails[i].ShortCut;
                System.Windows.Forms.Button Btn;
                cn = ctr.Find(str, true);
                Btn = (Button)cn[0];
                Btn.Text = objPosShortcutHelper.lstTableDetails[i].Discription;
                if (objPosShortcutHelper.lstTableDetails[i].SaleId == 0)
                {
                    Btn.ForeColor = Color.DarkGreen;
                }
                else
                {
                    Btn.ForeColor = Color.DarkRed;
                    Btn.Image = BumedianBM.Properties.Resources.cancel_32;
                    Btn.ImageAlign = ContentAlignment.MiddleCenter;
                }
                Btn.Font = new Font(Btn.Font, FontStyle.Bold);
                Btn.Enabled = true;
            }
        }

        #endregion

        #endregion



    }
}
