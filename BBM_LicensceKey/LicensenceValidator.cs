using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Security.Cryptography;
using System.IO;

namespace BBM_LicensceGenerator
{
    public class LicensenceValidator

    {
        //string appenderPrefix = "01";
        //string appenderSuffix = "09";
        string passPhrase = "HiSham";
        string saltValue = "Tripoli";
        string hashAlgorithm = "SHA1";
        int passwordIterations = 2;
        string initVector = "@1B2c3D4e5F6g7H8";
        int keySize = 256;

        public LicensenceValidator()
        {

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

        private string GetLicenceKey(string userSysKey,int isserver,string month)
        {
            try
            {
                //Add by thamil for Licence implementation On 3-March-2017
                //return (((long.Parse(userSysKey) / 4) * 16) / 5).ToString().PadLeft(10, '0').Substring(0, 10);
                string[] str = userSysKey.Split('-');
                if (str.Length != 2)
                    return string.Empty;
                string machineID = str[1].Remove(0,1);
                string substr = machineID.Substring(0, 10);
                string str1 = (((long.Parse(str[0]) / 4) * 16) / 5).ToString().PadLeft(10, '0').Substring(0, 10);
                string str2 = (((long.Parse(substr) / 4) * 16) / 5).ToString();
                //string str2 = machineID.ToString();
                return str1 + "-" + isserver + month+str2;
            }
            catch (Exception ex)
            {
                return "Incorrect User Key!";
            }
        }

        //Add by thamil for Licence implementation On 3-March-2017 for un used code
        //private bool ValidateLicenceKey(string key)
        //{
        //    return string.Equals(GetLicenceKey(GenerateActivationKey()), key);
        //}
       
        //public bool ValidateSerialKey(string inputKey)
        //{
        //    if (!string.IsNullOrEmpty(inputKey))
        //    {
        //        if (ValidateLicenceKey(inputKey))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public string GenerateActivationKey()
        {
            string result = GetAsciiValues(GetSystemFingerPrint()).PadRight(10, '0').Substring(0, 10);
            return result;
        }

        public string GenerateSerialKey(string activationKey,int isserver,string month)
        {
            return GetLicenceKey(activationKey,isserver,month);
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
    }
}
