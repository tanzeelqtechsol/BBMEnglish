using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.ServiceProcess;
using System.Printing;
using ObjectHelper;
using BumedianBM.ArabicView;
using System.Windows.Forms;
using CommonHelper;
using System.ServiceModel;
using System.Diagnostics;
using System.ServiceModel.Channels;
using POS;
using Microsoft.Win32;

namespace BumedianBM
{
    public class CashDrawer
    {
        static bool _continue;
        static SerialPort _serialPort;
        public void OpenCashDrawer()
        {
            try
            {
                if (GeneralOptionSetting.FlagUseCashDrawer == "Y")
                {
                    if (GeneralOptionSetting.FlagDrawerProtectWithPassword == "Y")
                    {
                        DB_Login ObjFrm = new DB_Login();
                        ObjFrm.lblUserName.Visible = ObjFrm.Txt_UserName.Visible = false;
                        ObjFrm.Tag = "Enter";
                        //  ObjFrm.btnLogin.Text = ChangeLanguageforCustomMsg("Enter");
                        ObjFrm.btnLogin.Name = "Btn_Enter";
                        ObjFrm.Text = "Cash Drawer Password";
                        if (ObjFrm.ShowDialog() != DialogResult.OK)
                        { return; }
                    }
                    if (GeneralOptionSetting.FlagDrawerTypeCOM == "Y")
                    {
                       // CashDrawerCommand();
                        OpenComCasgDrawer();
                    }
                    else if (GeneralOptionSetting.FlagDrawerTypeRJ11 == "Y")
                    {
                        CashDrawerCommand();
                    }
                    else if (GeneralOptionSetting.FlagDrawerTypeUSP == "Y")
                    {
                        CashDrawerCommand();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo("Unable to Open the CashDrawer", "Cash Drawer");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Drawer", "btnopenDrawer_Click");
            }
        }

        private void OpenComCasgDrawer()
        {
            try
            {
                string name;
                //string message;
                StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
                //   Thread readThread = new Thread(Read);

                // Create a new SerialPort object with default settings.
                _serialPort = new SerialPort();
                RegistryKey regkey = Registry.LocalMachine;
                // Allow the user to set the appropriate properties.

                if (Environment.Is64BitOperatingSystem)
                {
                    regkey = regkey.OpenSubKey("SOFTWARE\\Wow6432Node\\PROTEAM\\BBM", true);
                }
                else
                {
                    regkey = regkey.OpenSubKey("SOFTWARE\\PROTEAM\\BBM", true);
                }

                if (regkey != null && regkey.GetValue("PortName") != null)
                {
                    //if (regkey.GetValue("PortName") != null)
                    //{
                        _serialPort.PortName = SetPortName(_serialPort.PortName, regkey.GetValue("PortName").ToString());
                        _serialPort.BaudRate = SetPortBaudRate(_serialPort.BaudRate, regkey.GetValue("BaudRate").ToString());
                        _serialPort.Parity = SetPortParity(_serialPort.Parity, regkey.GetValue("Parity").ToString());
                        _serialPort.DataBits = SetPortDataBits(_serialPort.DataBits, regkey.GetValue("DataBits").ToString());
                        _serialPort.StopBits = SetPortStopBits(_serialPort.StopBits, regkey.GetValue("StopBits").ToString());
                        _serialPort.Handshake = SetPortHandshake(_serialPort.Handshake, regkey.GetValue("Handshake").ToString());
                    //}
                        _serialPort.ReadTimeout = 5000;
                        _serialPort.WriteTimeout = 5000;
                    if (_serialPort.IsOpen)
                        _serialPort.Close();
                    _serialPort.Open();
                    char openChar = (char)7;
                    _serialPort.Write(openChar.ToString());
                    _continue = true;

                    while (_continue)
                    {
                      _continue = false;
                      
                    }
                   _serialPort.Close();
                  //  _serialPort.Dispose();
                }
                else
                {
                    GeneralFunction.Information("PleaseconfiguretheCOMPortSetting", "BumedienBusinessManagement");
                    CashDrawerSetting comport = new CashDrawerSetting();
                    comport.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static void CashDrawerCommand()
        {
            try
            {
                //System.Diagnostics.Process _process = new System.Diagnostics.Process();
                //_process.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\" + "OpenDrawer.bat";
                //_process.StartInfo.RedirectStandardError = false;
                //_process.StartInfo.RedirectStandardOutput = false;
                //_process.StartInfo.UseShellExecute = false;
                //_process.StartInfo.CreateNoWindow = true;
                //_process.StartInfo.Verb = "runas";
                //_process.Start();
                //_process.WaitForExit();
                //System.Diagnostics.Process _process = new System.Diagnostics.Process();
                //_process.StartInfo.FileName = @"cscript";
                //_process.StartInfo.Arguments = "//B //Nologo " + System.Windows.Forms.Application.StartupPath + "\\" + "OpenDrawer.vbs";
                //_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //_process.StartInfo.ErrorDialog = false;
                //_process.Start();
                //_process.WaitForExit();
                //_process.Close();
                string escCashOpen = ((char)27).ToString() + ((char)112).ToString() + ((char)0).ToString() + ((char)60).ToString() + ((char)120).ToString();
                WindowsPrinter.PrintData(escCashOpen, WindowsPrinter.GetDefaultPrinter());

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo("Unable to Open the CashDrawer", "Cash Drawer");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Drawer", "btnopenDrawer_Click");
            }


        }
        public string SetPortName(string defaultPortName,string PortName)
        {
            try
            {
                string portName;
                portName = PortName;

                if (portName == "" || !(portName.ToLower()).StartsWith("com"))
                {
                    portName = defaultPortName;
                }
                return portName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Display BaudRate values and prompt user to enter a value. 
        public int SetPortBaudRate(int defaultPortBaudRate,string BaudRate)
        {
            try
            {
                string baudRate;
                baudRate = BaudRate;

                if (baudRate == "")
                {
                    baudRate = defaultPortBaudRate.ToString();
                }

                return int.Parse(baudRate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Display PortParity values and prompt user to enter a value. 
        public Parity SetPortParity(Parity defaultPortParity,string Parity)
        {
            try
            {
                string parity;
                parity = Parity;
                if (parity == "")
                {
                    parity = defaultPortParity.ToString();
                }

                return (Parity)Enum.Parse(typeof(Parity), parity, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Display DataBits values and prompt user to enter a value. 
        public int SetPortDataBits(int defaultPortDataBits,string DataBits)
        {
            try
            {
                string dataBits;
                dataBits = DataBits;
                if (dataBits == "")
                {
                    dataBits = defaultPortDataBits.ToString();
                }
                return int.Parse(dataBits.ToUpperInvariant());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Display StopBits values and prompt user to enter a value. 
        public StopBits SetPortStopBits(StopBits defaultPortStopBits,String StopBits)
        {
            try
            {
                string stopBits;
                stopBits = StopBits;
                if (stopBits == "")
                {
                    stopBits = defaultPortStopBits.ToString();
                }
                return (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Handshake SetPortHandshake(Handshake defaultPortHandshake,string HandShake)
        {
            try
            {

                string handshake;
                handshake = HandShake;
                if (handshake == "")
                {
                    handshake = defaultPortHandshake.ToString();
                }
                return (Handshake)Enum.Parse(typeof(Handshake), handshake, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    public class WindowsPrinter
    {

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        static Dictionary<string, IntPtr> dicPntr = new Dictionary<string, IntPtr>();

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            //GeneralFunction.Trace("SendBytesToPrinter Start");
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            try
            {
                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";
                bool printerStatus = true;

                if (dicPntr.ContainsKey(szPrinterName.Normalize()))
                {
                    hPrinter = dicPntr[szPrinterName.Normalize()];
                }
                else
                {
                    printerStatus = OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero);
                    if (printerStatus)
                    {
                        dicPntr.Add(szPrinterName.Normalize(), hPrinter);
                    }
                    else
                    {
                        //GeneralFunction.Trace("Failed to open the printer - " + szPrinterName.Normalize());
                    }
                }

                // Open the printer.
                //if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                //{    
                if (printerStatus)
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                }
                //ClosePrinter(hPrinter);
                //}
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                //GeneralFunction.Trace("SendBytesToPrinter End");
                return bSuccess;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            fs.Close();
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            //List<string> printQueueList = null;
            //printQueueList = GetPrintersName();
            ////if (//GeneralFunction.IsDebug)
            //    System.Windows.Forms.MessageBox.Show(szString, "Print", System.Windows.Forms.MessageBoxButtons.OK);
            //PrinterSettings settings = new PrinterSettings();
            //settings.PrinterName = szPrinterName;
            //if (settings.IsDefaultPrinter)//Printer Queue list commended to fix CashDrawer cant Opened.
            //{
                //GeneralFunction.Trace("SendStringToPrinter Start");
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);

                //GeneralFunction.Trace("SendStringToPrinter End");
                return true;
            //}
            //else
            //    return false;
        }

        /// <summary>
        /// This function is for getting the default printer form system.
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);

        public static List<string> GetPrintersName(List<System.Printing.PrintQueue> printQueueList = null)
        {
            try
            {
                if (printQueueList == null)
                {
                    printQueueList = GetInstalledPrinters();
                }
                List<string> printerNameList = new List<string>();
                foreach (System.Printing.PrintQueue printQueue in printQueueList)
                {
                    string printerName = (printQueue.Description.Contains(',') ?
                        printQueue.Description.Remove(printQueue.Description.IndexOf(',')) : printQueue.Description);
                    printerNameList.Add(printerName.ToUpper());
                }

                return printerNameList;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all installed network and local printersfrom machine. 
        /// </summary>
        /// <returns></returns>
        private static List<System.Printing.PrintQueue> GetInstalledPrinters()
        {
            try
            {
                PrintServer localPrintServer = new PrintServer();
                PrintQueueCollection printQueues = localPrintServer.GetPrintQueues(
                    new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
                var printerList = (from printer in printQueues select printer).ToList();
                return printerList;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private static void PrintByTCPIPPrinter(string printMsg, string ipAddress, int portNumber)
        {
            try
            {

                NetworkStream ns = null;
                Socket socket = null;
                IPEndPoint adresIP = new IPEndPoint(IPAddress.Parse(ipAddress), portNumber);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IAsyncResult result = socket.BeginConnect(ipAddress, portNumber, null, null);
                bool sucess = result.AsyncWaitHandle.WaitOne(1000, true);
                if (!sucess)
                {
                    socket.Close();
                }
                else
                {

                    //  socket.Connect(adresIP);
                    ns = new NetworkStream(socket);

                    byte[] toSend = Encoding.ASCII.GetBytes(printMsg);
                    ns.Write(toSend, 0, toSend.Length);
                    ns.Flush();

                    if (ns != null)
                    {
                        ns.Close();
                    }
                    if (socket != null && socket.Connected)
                    {
                        socket.Close();
                    }
                }
            }
            catch (System.Exception ex)
            {

                //GeneralFunction.ErrorLogFile(ex, "Print");
            }

        }

        private static void PrintByDirectToPort(string printMsg, string portName, int baudRate)
        {
            try
            {
                System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort();
                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.Parity = Parity.None;


                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Handshake = Handshake.None;

                serialPort.Encoding = Encoding.ASCII;
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                }

                serialPort.WriteLine(printMsg);
                serialPort.Close();
            }
            catch (System.Exception ex)
            {
                //GeneralFunction.ErrorLogFile(ex, "Print");
            }
        }


        public static void PrintData(string _printMsg, string printName)
        {
            //if (printerDetail != null)
            //{
            PrintInformation pi = new PrintInformation();
            pi.printMsg = _printMsg;
            pi.printerName = printName;
            //pi.portNumber = printerDetail.PrintFontSize.Value;
            //pi.printConnectivityType = printerDetail.PrinterConnectivityType;
            SendToPrinter(pi);
            Thread.Sleep(50);
            //}
        }

        public static void InitPrinterServices()
        {
            //GeneralFunction.StartBeVoService();
            BBMPrinterProxy b = new BBMPrinterProxy();
        }

        private static void SendToPrinter(PrintInformation printerDetail)
        {
            //if (printerDetail.printConnectivityType == (int)//GeneralFunction.DrawerPortType.COMPort)
            //{
            //    PrintByDirectToPort(printerDetail.printMsg, printerDetail.printerName, printerDetail.portNumber);
            //}
            //else if (printerDetail.printConnectivityType == (int)//GeneralFunction.DrawerPortType.Printer)
            //{
            SendStringToPrinter(printerDetail.printerName, printerDetail.printMsg);
            //}
            //else if (printerDetail.printConnectivityType == (int)//GeneralFunction.DrawerPortType.TCPIP)
            //{
            //    //if (//GeneralFunction.IsConnectedToInternet(printerDetail.Printer))
            //    //{
            //    PrintByTCPIPPrinter(printerDetail.printMsg, printerDetail.printerName, printerDetail.portNumber);
            //    //  }
            //}
        }

        struct PrintInformation
        {
            public string printMsg;
            public string printerName;
            public int portNumber;
            public int printConnectivityType;
        }

    }
    [ServiceContract]
    public interface IBBMService
    {
        [OperationContract]
        string GetLocalTime();
        [OperationContract]
        bool SendStringToPrinter(string printerName, string printMessage);
        [OperationContract]
        bool PrintByTCPIPPrinter(string printMessage, string ipAddress, int portNumber);
        [OperationContract]
        bool PrintByDirectToPort(string printMessage, string portName, int baudRate);
        [OperationContract]
        List<string> GetPrintersName(List<PrintQueue> printQueueList);
        [OperationContract]
        List<PrintQueue> GetInstalledPrinters();
    }
    public class BBMPrinterProxy : System.ServiceModel.ClientBase<IBBMService>, IBBMService
    {
        public BBMPrinterProxy()
        {
        }
        public List<PrintQueue> GetInstalledPrinters()
        {
            return base.Channel.GetInstalledPrinters();
        }
        public List<string> GetPrintersName(List<PrintQueue> printQueueList)
        {
            return base.Channel.GetPrintersName(printQueueList);
        }
        public bool PrintByDirectToPort(string printMessage, string portName, int baudRate)
        {
            return base.Channel.PrintByDirectToPort(printMessage, portName, baudRate);
        }
        public bool PrintByTCPIPPrinter(string printMessage, string ipAddress, int portNumber)
        {
            return base.Channel.PrintByTCPIPPrinter(printMessage, ipAddress, portNumber);
        }
        public bool SendStringToPrinter(string printerName, string printMessage)
        {
            return base.Channel.SendStringToPrinter(printerName, printMessage);
        }
        public string GetLocalTime()
        {
            return base.Channel.GetLocalTime();
        }
    }
}
