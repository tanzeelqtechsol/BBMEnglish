using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using CommonHelper;
using BumedianBM.ViewHelper;

namespace BumedianBM.View
{
    public partial class AdditionalBarcode : Form
    {
        //LoginViewHelper loginViewHelper;
        //LoginObjectClass loginObjectHelper;
        public AdditionalBarcode()
        {
            InitializeComponent();
            //loginObjectHelper = new LoginObjectClass();
            //loginViewHelper = new LoginViewHelper(this);
        }
        private void Enter_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SetObjectFromControl();
            //    loginViewHelper.LoginFunction();
            //}
            //catch (Exception ex)
            //{
            //    GeneralFunction.Errorlogfile(ex.Message, "Admin", "Login", "Enter_Click");
            //}
        }
        private void SetObjectFromControl()
        {
            try
            {
                //loginViewHelper.balClass.ObjLoginObject.UserName = this.Txt_UserName.Text.Trim();
                //loginViewHelper.balClass.ObjLoginObject.Password = this.Txt_Password.Text.Trim();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        private void Number_Click(object sender, EventArgs e)
        {
            try
            {
                //Button text = sender as Button;
                //if ((loginViewHelper.balClass.ObjLoginObject.NumberPadText == String.Empty || loginViewHelper.balClass.ObjLoginObject.NumberPadText == null) && Txt_Password.Text.Trim() != string.Empty)
                //{
                //    loginViewHelper.balClass.ObjLoginObject.NumberPadText = Txt_Password.Text;
                //}
                //loginViewHelper.balClass.ObjLoginObject.NumberPadText += text.Text;
                //Txt_Password.Text = loginViewHelper.balClass.ObjLoginObject.NumberPadText;
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, 101,"Login", "Enter_Click");
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Txt_Password.Text = loginViewHelper.balClass.ObjLoginObject.NumberPadText = string.Empty;
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, 101, "Login", "Enter_Click");
            }
        }
    }
}
