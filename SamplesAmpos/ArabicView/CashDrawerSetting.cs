using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Win32;

namespace BumedianBM.ArabicView
{
    public partial class CashDrawerSetting : Form
    {
        public CashDrawerSetting()
        {
            InitializeComponent();
            SetLanguage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             RegistryKey regkey = Registry.LocalMachine;
             if (regkey.OpenSubKey("SOFTWARE\\PROTEAM\\BBM") != null)
             {
                 if (Environment.Is64BitOperatingSystem)
                 {
                     regkey = regkey.OpenSubKey("SOFTWARE\\Wow6432Node\\PROTEAM\\BBM",true);
                 }
                 else
                 {
                     regkey = regkey.OpenSubKey("SOFTWARE\\PROTEAM\\BBM",true);
                 }
                 if (!Validation())
                     return;
                 AssignValuesToReg(regkey);
             }
             else
             {
                 if (!Validation())
                     return;
                 if (Environment.Is64BitOperatingSystem)
                 {
                     Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\PROTEAM");
                     Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\PROTEAM\\BBM");
                     regkey = regkey.OpenSubKey("SOFTWARE\\Wow6432Node\\PROTEAM\\BBM", true);
                 }
                 else
                 {
                     Registry.LocalMachine.CreateSubKey("SOFTWARE\\PROTEAM");
                     Registry.LocalMachine.CreateSubKey("SOFTWARE\\PROTEAM\\BBM");
                     regkey = regkey.OpenSubKey("SOFTWARE\\PROTEAM\\BBM", true);
                 }
                 AssignValuesToReg(regkey);
             }
             this.Close();
        }

        private void AssignValuesToReg(RegistryKey regkey)
        {
            regkey.SetValue("PortName", cmbPortNames.Text);
            regkey.SetValue("BaudRate", txtBaudRate.Text);
            regkey.SetValue("Parity", cmbParity.Text);
            regkey.SetValue("DataBits", txtDataBits.Text);
            regkey.SetValue("StopBits", cmbStopBits.Text);
            regkey.SetValue("Handshake", cmbHandshake.Text);
        }

        private void AssignValuesFromReg()
        {
            RegistryKey regkey = Registry.LocalMachine;
            if (regkey.OpenSubKey("SOFTWARE\\PROTEAM\\BBM") != null)
            {
                regkey = regkey.OpenSubKey("SOFTWARE\\PROTEAM\\BBM", true);
                if (regkey.GetValue("PortName") != null || regkey.GetValue("BaudRate") != null)
                {
                    cmbHandshake.Text = regkey.GetValue("Handshake").ToString();
                    cmbParity.Text = regkey.GetValue("Parity").ToString();
                    cmbPortNames.Text = regkey.GetValue("PortName").ToString();
                    cmbStopBits.Text = regkey.GetValue("StopBits").ToString();
                    txtBaudRate.Text = regkey.GetValue("BaudRate").ToString();
                    txtDataBits.Text = regkey.GetValue("DataBits").ToString();
                }
            }
        }

        private void CashDrawerSetting_Load(object sender, EventArgs e)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                cmbPortNames.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                cmbParity.Items.Add(s);
            }
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                cmbStopBits.Items.Add(s);
            }
            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                cmbHandshake.Items.Add(s);
            }
            AssignValuesFromReg();
        }

        private bool Validation()
        {
            if (cmbPortNames.SelectedIndex == -1)
            {
                CommonHelper.GeneralFunction.Information("PleaseselecttheCOMPortName", "BumedienBusinessManagement");
                return false;
            }
            return true;

        }

        private void SetLanguage()
        {
            lblBaudRate.Text = Additional_Barcode.GetValueByResourceKey("BaudRate");
            lblDataBits.Text = Additional_Barcode.GetValueByResourceKey("DataBits");
            lblHandShake.Text = Additional_Barcode.GetValueByResourceKey("HandShake");
            lblParity.Text = Additional_Barcode.GetValueByResourceKey("Parity");
            lblPortName.Text = Additional_Barcode.GetValueByResourceKey("PortName");
            lblStopBits.Text = Additional_Barcode.GetValueByResourceKey("StopBits");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            this.Text = Additional_Barcode.GetValueByResourceKey("ComSetting");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
