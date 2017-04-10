using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;

namespace PRI_NaszSamochod
{
    public class AuthenticationRSA
    {
        public static void GenerateKeys(string publicKeyFileName, string privateKeyFileName)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsa = null;
            StreamWriter publicKeyFile = null;
            StreamWriter privateKeyFile = null;
            string publicKey = "";
            string privateKey = "";

            try
            {
                cspParams = new CspParameters();
                cspParams.ProviderType = 1;
                // cspParams.ProviderName;
                cspParams.Flags = CspProviderFlags.UseArchivableKey;
                cspParams.KeyNumber = (int)KeyNumber.Exchange;
                rsa = new RSACryptoServiceProvider(cspParams);

                publicKey = rsa.ToXmlString(false);

                publicKeyFile = File.CreateText(publicKeyFileName);
                publicKeyFile.Write(publicKey);

                privateKey = rsa.ToXmlString(true);

                privateKeyFile = File.CreateText(privateKeyFileName);
                privateKeyFile.Write(privateKey);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Source);
                Debug.WriteLine(e.Message);
            }
            finally
            {
                if(publicKeyFile != null)
                {
                    publicKeyFile.Close();
                }
                if(privateKeyFile != null)
                {
                    privateKeyFile.Close();
                }
            }
        }

        public static void Encypt()
        {

        }

        public static void Decrypt()
        {

        }
    }
}