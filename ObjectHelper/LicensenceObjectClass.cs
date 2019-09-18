using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Management;
using System.IO;
using CommonHelper;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace ObjectHelper
{
   public  class LicensenceObjectClass
    {
        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);
        //string appenderPrefix = "01";
        //string appenderSuffix = "09";
        string passPhrase = "HiSham";
        string saltValue = "Tripoli";
        string hashAlgorithm = "SHA1";
        int passwordIterations = 2;
        string initVector = "@1B2c3D4e5F6g7H8";
        int keySize = 256;

        public LicensenceObjectClass()
        {

        }

        /// <summary>
        /// This function is used to get the given hard drive serial number
        /// </summary>
        /// <param name="strDriveLetter"></param>
        /// <returns>Drive Serial Number</returns>
        private string GetVolumeSerial(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            strDriveLetter += ":\\"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);
            return Convert.ToString(serNum);
        }

        private string GetSystemFingerPrint()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            string result = string.Empty;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                result += ((wmi_HD["SerialNumber"] != null) ? wmi_HD["SerialNumber"].ToString() : string.Empty);
            }
            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                result += ((wmi_HD["SerialNumber"] != null) ? wmi_HD["SerialNumber"].ToString() : string.Empty);
            }
            return result.Trim();
        }

        public string EnptKeys(string plainText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        public string DeptKeys(string cipherText)
        {
            string plainText = "error";
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            }
            catch { }
            return plainText;
        }

        private string GetLicenceKey(string userSysKey)
        {
            //Add by thamil for Licence implementation On 3-March-2017
            //return (((long.Parse(userSysKey) / 4) * 16) / 5).ToString().PadLeft(10, '0').Substring(0, 10);
            string isServer = string.Empty;
            if (CommonHelper.GeneralFunction.IsServer)
                isServer = "1";
            else
                isServer = "0";

            string[] str = userSysKey.Split('-');
            if (str.Length != 2)
                return string.Empty;
            string machineID = str[1].Remove(0,1);
            string substr = machineID.Substring(0, 10);
            string str1 = (((long.Parse(str[0]) / 4) * 16) / 5).ToString().PadLeft(10, '0').Substring(0, 10);
            string str2 = (((long.Parse(substr) / 4) * 16) / 5).ToString();
            return str1 + "-" +isServer+ str2;

        }

        private bool ValidateLicenceKey(string key)
        {
            return string.Equals(GetLicenceKey(GenerateActivationKey()), key);
        }

        public bool ValidateSerialKey(string inputKey)
        {
            if (!string.IsNullOrEmpty(inputKey))
            {
                if (ValidateLicenceKey(inputKey))
                {
                    return true;
                }
            }
            return false;
        }

        public string GenerateActivationKey()
        {
            string isServer = string.Empty;
            string version = string.Empty;
            if (CommonHelper.GeneralFunction.IsServer)
                isServer = "1";
            else
                isServer = "0";

            //
            RegistryKey _regkey = Registry.LocalMachine;
            if ((_regkey.OpenSubKey(GeneralFunction.RegEditPath)) != null)
            {
                _regkey = _regkey.OpenSubKey(GeneralFunction.RegEditPath, true);
                version = GeneralFunction.Decrypt(_regkey.GetValue("Version").ToString());

                decimal Ver = Convert.ToDecimal(version) * 100;
                version = Convert.ToInt32(Ver).ToString();
            }
            //

                //string result = GetAsciiValues(GetSystemFingerPrint()).PadRight(10, '0').Substring(0, 10);
                string result = GetAsciiValues(GetVolumeSerial("C")).PadRight(10, '0').Substring(0, 10);
            //Add by thamil For implement the MACAddress
            string machineID = GetMachineID(); //MotherBoardID();
            machineID = machineID.Remove(0, 1);
            string result1 = GetAsciiValues(machineID);
            return version + result + "-" + isServer + version + result1 + version;
        }

        public string GenerateSerialKey(string activationKey)
        {
            return GetLicenceKey(activationKey);
        }

        private string GetAsciiValues(string input)
        {
            string result = string.Empty;
            char[] arrChars = input.ToCharArray();
            foreach (char ch in arrChars)
            {
                result += (int)ch;
            }
            return result;
        }
        public string TextEnc(string SrcString)
        {
            string BlockCode = "H" + "I" + "J" + "K" + "T" + "U" + "V" + "W" + "X" + "Y" + "Z" + "0" + "1" + "A" + "2" + "3" + "B" + "4" + "5" + "C" + "6" + "7" + "D" + "8" + "9" + "E" + "F" + "G" + "L" + "M" + "N" + "O" + "P" + "Q" + "R" + "S";
            int MaxRange = BlockCode.Length - 1;
            Random RandomClass = new Random();
            return TextEncrypt(SrcString, RandomClass.Next(0, MaxRange), BlockCode);
        }
        private string TextEncrypt(string SrcString, int FixValue, string CryptPattern)
        {
            if (SrcString.Length > 0)
            {
                string BlockCode = CryptPattern;


                int i = 0;
                int MaxRange = BlockCode.Length - 1;
                int RandomValue = FixValue;
                if (FixValue > MaxRange)
                {
                    FixValue = 44;
                }

                string TextResult = BlockCode[RandomValue].ToString();
                int EncryptValue;
                for (i = 0; i < SrcString.Length; i++)
                {
                    if (BlockCode.IndexOf(SrcString[i].ToString()) >= 0)
                    {
                        EncryptValue = BlockCode.IndexOf(SrcString[i].ToString()) + RandomValue;
                        if (EncryptValue > MaxRange)
                        {
                            EncryptValue = EncryptValue - (MaxRange + 1);
                        }
                        TextResult += BlockCode[EncryptValue].ToString();
                    }
                    else
                    {
                        TextResult += SrcString[i].ToString();
                    }
                }

                //Replace
                //TextResult = "T9GB5ECEDC";
                char RplChar = ' ';
                char[] ChrArray = TextResult.ToCharArray();

                for (i = 0; i <= ChrArray.GetUpperBound(0); i++)
                {
                    if (ChrArray[i].ToString() == " ")
                    {
                        ChrArray[i] = "`"[0];
                    }
                }

                int PrevPos = -1;

                for (i = 0; i <= ChrArray.GetUpperBound(0); i++)
                {
                    if ((i % 2) == 0)
                    {
                        RplChar = ChrArray[i];
                        PrevPos = i;
                    }
                    else
                    {
                        if (PrevPos > -1)
                        {
                            ChrArray[PrevPos] = ChrArray[i];
                            ChrArray[i] = RplChar;
                        }
                    }
                }


                TextResult = "";

                for (i = 0; i <= ChrArray.GetUpperBound(0); i++)
                {
                    TextResult += ChrArray[i];
                }

                return TextResult;
            }
            else
            {
                return SrcString;
            }
        }
        public string TextDec(string SourceString)
        {
            return TextDecrypt(SourceString, "H" + "I" + "J" + "K" + "T" + "U" + "V" + "W" + "X" + "Y" + "Z" + "0" + "1" + "A" + "2" + "3" + "B" + "4" + "5" + "C" + "6" + "7" + "D" + "8" + "9" + "E" + "F" + "G" + "L" + "M" + "N" + "O" + "P" + "Q" + "R" + "S");
        }
        private string TextDecrypt(string SourceString, string CryptPattern)
        {
            if (SourceString.Length > 0)
            {
                string BlockCode = CryptPattern;
                int i = 0;
                int MaxRange = BlockCode.Length - 1;
                string TextResult = "";
                int EncryptValue;
                string SrcString = "";

                //Replace

                char RplChar = ' ';
                char[] ChrArray = SourceString.ToCharArray();

                for (i = 0; i <= ChrArray.GetUpperBound(0); i++)
                {
                    if (ChrArray[i].ToString() == "`")
                    {
                        ChrArray[i] = " "[0];
                    }
                }

                int PrevPos = -1;

                for (i = 0; i <= ChrArray.GetUpperBound(0); i++)
                {
                    if ((i % 2) == 0)
                    {
                        RplChar = ChrArray[i];
                        PrevPos = i;
                    }
                    else
                    {
                        if (PrevPos > -1)
                        {
                            ChrArray[PrevPos] = ChrArray[i];
                            ChrArray[i] = RplChar;
                        }
                    }
                }

                SrcString = "";

                for (i = 0; i <= ChrArray.GetUpperBound(0); i++)
                {
                    SrcString += ChrArray[i];
                }

                //'De Encrypt

                int RandomValue = BlockCode.IndexOf(SrcString[0].ToString());

                for (i = 1; i < SrcString.Length; i++)
                {
                    if (BlockCode.IndexOf(SrcString[i].ToString()) >= 0)
                    {
                        EncryptValue = BlockCode.IndexOf(SrcString[i].ToString()) - RandomValue;
                        if (EncryptValue < 0)
                        {
                            EncryptValue = EncryptValue + (MaxRange + 1);
                        }

                        TextResult += BlockCode[EncryptValue];
                    }
                    else
                    {
                        TextResult += SrcString[i].ToString();
                    }
                }

                return TextResult;
            }
            else
            {
                return SourceString;
            }
        }

        // Due to MotherBoardID issue, we added the 3 type of Hardware ID to find the MachineID  Done by Praba on 21-Jun-2017
        public static string GetMachineID()
        {
            try
            {
                string MachineID = "";
                MachineID = GetHDDAddress();

                if ((MachineID == null) || MachineID == "" || MachineID.Length < 3 )
                {
                    MachineID = GetMacAddress();
                }

                if ((MachineID == null) || MachineID == "" || MachineID.Length < 3)
                {
                    MachineID = GetMotherBoardID(); //LicensenceObjectClass.MotherBoardID();
                }

                if ((MachineID == null) || MachineID == "" || MachineID.Length < 3)
                {
                    MachineID = GetCpuId();
                }

                string isserver = string.Empty;
                string curFile = AppDomain.CurrentDomain.BaseDirectory + "IT.dat";
                if (File.Exists(curFile) == true)
                {
                    isserver = "1";
                }
                else
                {
                    isserver = "0";
                }
                MachineID = isserver + MachineID;
                GeneralFunction.Trace("MachineID:" + MachineID);
                return MachineID;
            }
            catch (Exception ex)
            {
                GeneralFunction.Trace(ex.Message);
                return "";
            }
        }

        private static string GetHDDAddress()
        {
            //string drive = "C";
            //ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            //dsk.Get();
            //string volumeSerial = dsk["VolumeSerialNumber"].ToString();
            //return volumeSerial;
            try
            {
                //GeneralFunction.Trace("GetHDDAddress Started");
                //var HDDNo = string.Empty;
                //ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
                //foreach (ManagementObject queryObj in searcher.Get())
                //{
                //    HDDNo = queryObj["SerialNumber"].ToString();
                //}
                //return HDDNo;
                ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
                ManagementObjectCollection mcol = mangnmt.GetInstances();
                string result = "";
                foreach (ManagementObject strt in mcol)
                {
                    result = Convert.ToString(strt["VolumeSerialNumber"]);
                    break;
                }

                return result;
            }
            catch (Exception ex)
            {
                //GeneralFunction.Trace(ex.Message);
                return "";
            }
        }

        private static string GetCpuId()
        {
            string cpuid = null;
            try
            {
                ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");
                foreach (var item in mo.Get())
                {
                    cpuid = item["ProcessorId"].ToString();
                }
                return cpuid;
            }
            catch
            {
                return "";
            }
        }

        private static string GetMacAddress()
        {
            try
            {
                string macAddresses = "";

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    macAddresses = nic.GetPhysicalAddress().ToString();
                    break;
                }
                return macAddresses;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string GetMotherBoardID()
        {
            String serial = "";
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();
                foreach (ManagementObject mo in moc)
                {
                    serial = mo["SerialNumber"].ToString();
                }
                return serial;
            }
            catch (Exception)
            {
                return serial;
            }
        }
    }
}
