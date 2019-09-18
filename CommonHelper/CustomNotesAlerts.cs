using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;


namespace CommonHelper
{
    public class CustomNotesAlerts
    {
        private static string str = string.Empty;
        public enum messageType { sale, custom, empty };
        public static void SetPaymentDateIn_NoteAlert(RichTextBox RtxtNotesAndAlerts)
        {

            try
            {
                if (GeneralOptionSetting.FlagAlertPayDates == "Y")
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] param = new SqlParameter[0];
                    ds = GeneralFunction.ExecuteQueryDataset("Sp_Get_PaymentDate_A", param, "Purchase");
                    int paybefor = Convert.ToInt32(GeneralOptionSetting.FlagAlertPayDatesBefore);
                    if (paybefor > 0)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "\n";
                           // RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + GeneralFunction.ChangeLanguageforCustomMsg("PaymentDate");
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                TimeSpan tp = Convert.ToDateTime(ds.Tables[1].Rows[i]["PaymentDate"].ToString()).Subtract(Convert.ToDateTime(DateTime.Now));
                                if ((tp.Days <= paybefor) & (tp.Days >= 0))
                                {
                                    str = ds.Tables[1].Rows[i]["AgentName"].ToString() + "---" + Convert.ToDateTime(ds.Tables[1].Rows[i]["PaymentDate"].ToString()).ToShortDateString();
                                    if (str != string.Empty)
                                    {
                                        RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + GeneralFunction.ChangeLanguageforCustomMsg("PaymentDate");
                                        RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + '\n' + str;
                                    }
                                }
                                //if (str == string.Empty)
                                //    if (RtxtNotesAndAlerts.Text.Contains(GeneralFunction.ChangeLanguageforCustomMsg("PaymentDate")))
                                //        RtxtNotesAndAlerts.Text.Replace(GeneralFunction.ChangeLanguageforCustomMsg("PaymentDate"), string.Empty);
                                // RtxtNotesAndAlerts.Text = string.Empty;
                            }

                        }
                    }
                    else
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "\n";
                            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + GeneralFunction.ChangeLanguageforCustomMsg("PaymentDate");
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                str = ds.Tables[0].Rows[i]["AgentName"].ToString();
                                RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + '\n' + str;
                            }
                        }
                }
                // PayDay Message for Supplier  // Added on 28-Oct-2014 by Seenivasan
                if (GeneralFunction.OnlyPayDaysForSupplier.Count > 1)
                {
                    for (int i = 0; i < GeneralFunction.OnlyPayDaysForSupplier.Count; i++)
                    {
                        RtxtNotesAndAlerts.Text += GeneralFunction.OnlyPayDaysForSupplier[i].ToString() + "\n\r";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Set_ReorderItemsIn_NoteAlert(RichTextBox RTX_Notes)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[0];
                dt = GeneralFunction.ExecuteQueryDatatable("Sp_Get_ReorderItems", param, "ReorderItems");
                if (dt.Rows.Count > 0)
                {
                    RTX_Notes.Text = RTX_Notes.Text + "\n ";
                    RTX_Notes.Text = RTX_Notes.Text + "\n " + GeneralFunction.ChangeLanguageforCustomMsg("ReorderItems");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void Set_NotesAlertDetails(RichTextBox RTX_Notes)
        {
            try
            {
                GeneralFunction.GetOptionDatas();
                if (GeneralFunction.NotesInVisible == "YES")
                {
                    RTX_Notes.Text = RTX_Notes.Text + "\n ";
                    //  RTX_Notes.Text = new Font("Microsoft Sans Serif", FontStyle.Bold);
                    RTX_Notes.Text = RTX_Notes.Text + GeneralFunction.ChangeLanguageforCustomMsg("NotificationDates");
                    //                    RTX_Notes.Text = RTX_Notes.Text + "\n " + "-------------------------------";
                    // RTX_Notes.Text = RTX_Notes.Text + "\n ";
                    // for (int k = 0; k < Obj_CommonClass.Notes.Count; k++)
                    for (int k = 0; k < GeneralFunction.OnlyNotes.Count; k++)
                    {
                        string[] Date = GeneralFunction.OnlyNotes[k].ToString().Split(':');

                        RTX_Notes.Text += " " + "\r\n  " + Date[0].ToString();
                        RTX_Notes.Text += " " + "\r\n     " + Date[1].ToString();
                        //RTX_Notes.Text += "\r\n ";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void CustomerMessage(string price, string total, messageType msgType)
        {

            string str = string.Empty;

            try
            {
                string portName = System.Configuration.ConfigurationManager.AppSettings["COMPort"].ToString();
                if (GeneralOptionSetting.FlagUseCustomerDisplay == "Y" && portName != string.Empty)
                {
                    SerialPort sp = new SerialPort();
                    sp.PortName = portName;
                    sp.BaudRate = 9600;
                    sp.Parity = Parity.None;
                    sp.DataBits = 8;
                    sp.StopBits = StopBits.One;
                    sp.Open();

                    switch (msgType)
                    {
                        case messageType.sale:
                            string strPrice, strTotal;
                            strPrice = "  Price : " + price;
                            strTotal = "  Total : " + total;
                            str = strTotal.PadRight(20, ' ') + strPrice.PadRight(20, ' ');
                            break;
                        case messageType.custom:

                            if (GeneralOptionSetting.FlagFirstLineWelcomeNote != string.Empty)
                            {
                                str = GeneralOptionSetting.FlagSecondLineWelcomeNote.PadRight(20, ' ') + GeneralOptionSetting.FlagFirstLineWelcomeNote.PadRight(20, ' ');
                            }
                            else
                            {
                                str = string.Empty.PadRight(20, ' ') + GeneralOptionSetting.FlagSecondLineWelcomeNote.PadRight(20, ' ');
                            }

                            break;
                        case messageType.empty:
                            str = string.Empty.PadRight(40, ' ');
                            break;
                    }

                    sp.WriteLine(((char)12).ToString());
                    sp.WriteLine(str);
                    sp.Close();
                    sp.Dispose();
                    sp = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Customer Display :" + ex.Message, "CustomerMessage Function", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "CustomerMessage Function", "CustomerMessage()");
            }
        }

    }
}
