using System;
using System.Windows.Forms;
using BALHelper;
using ObjectHelper;
using BumedianBM.View;

namespace BumedianBM
{
    public partial class Form1 : Form
    {

       
        #region Constructor
        public Form1()
        {
          InitializeComponent();
          
        } 
        #endregion
       
        #region Event

        private void Form1_Load(object sender, EventArgs e)
        {
               
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                var fromClass = new ValidationClass(this);
                var balClass = new BALClass();
                balClass.SetItemObject();
                balClass.ItemObject.UName = this.textBox1.Text;
                balClass.ItemObject.Password = this.textBox2.Text;
                if (fromClass.ValidationForLoginDeails() == true)
                {

                    if (balClass.Check_Userlogin() == true)
                    {
                        AgentDetails agentDetails = new AgentDetails();
                        agentDetails.ShowDialog();
                    }
                    else
                        MessageBox.Show("UserName or Password is Invalide");
                }

            }
            catch (Exception ex)
            {

                throw ex;
       
            }

        } 
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            PrimaryInfo form = new PrimaryInfo();
            form.ShowDialog();
        }

      
    }
}
