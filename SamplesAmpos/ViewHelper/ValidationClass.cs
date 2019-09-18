using System;
using System.Windows.Forms;

namespace BumedianBM
{
    public class ValidationClass
    {
       
          Form1 frm;   
       
        public ValidationClass(Form1 form)
        {
            frm = form;
          
        }

     
        #region Validation

        public Boolean ValidationForLoginDeails()
        {
            try
            {

                if (frm.textBox1.Text.Trim() == string.Empty)
                {
                    frm.textBox1.Focus();
                    MessageBox.Show("UserName is required");
                    return false;
                }
                if (frm.textBox2.Text.Trim() == string.Empty)
                {
                    frm.textBox2.Focus();
                    MessageBox.Show("Password is required");
                    return false;
                }

                return true;

            }
            catch (Exception ex) { throw ex; }

        }
        #endregion

        
  
    }
}
