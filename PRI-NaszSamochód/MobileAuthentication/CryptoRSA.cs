using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PRI_NaszSamochod.MobileAuthentication
{
    /// <summary>
    /// Klasa obsługująca generowanie kluczy, szyfrowanie i deszyfrowanie
    /// </summary>
    public class CryptoRSA
    {
        //TODO
        private static bool successfullyEncrypted;
        private static bool successfullyDecrypted;

        /// <summary>
        /// Generate RSA public and private keys
        /// </summary>
        /// <param name="keySize"></param>
        /// <returns>string[] contains public and private key in that order</returns>
        public static void GenerateKeys(int keySize)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaCryptoServiceProvider = null;
            string publicKey = "";
            string privateKey = "";

            try
            {
                cspParams = new CspParameters();
                cspParams.ProviderType = 1;
                cspParams.Flags = CspProviderFlags.UseArchivableKey;
                cspParams.KeyNumber = (int)KeyNumber.Exchange;
                rsaCryptoServiceProvider = new RSACryptoServiceProvider(keySize, cspParams);

                publicKey = rsaCryptoServiceProvider.ToXmlString(false);

                privateKey = rsaCryptoServiceProvider.ToXmlString(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Source);
                Debug.WriteLine(e.Message);
            }
            KeysHolder.PrivateKey = privateKey;
            KeysHolder.PublicKey = publicKey;
        }

        /// <summary>
        /// RSA Encryption
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="plainText"></param>
        /// <param name="IsOAEPActive"></param>
        /// <returns>byte[] of encrypted text</returns>
        public static byte[] Encrypt(string publicKey, string plainText, bool IsOAEPActive)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaCryptoServiceProvider = null;
            byte[] plainBytes = null;

            try
            {
                cspParams = new CspParameters();
                cspParams.ProviderType = 1;

                rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParams);
                rsaCryptoServiceProvider.FromXmlString(publicKey);
                //Encryption
                plainBytes = Encoding.Unicode.GetBytes(plainText);

                successfullyEncrypted = true;
                return rsaCryptoServiceProvider.Encrypt(plainBytes, IsOAEPActive);
            }
            catch (Exception e)
            {
                successfullyEncrypted = false;
                Debug.WriteLine(e.Source);
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// RSA Decryption
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="encryptedBytes"></param>
        /// <param name="IsOAEPActive"></param>
        /// <returns>string with plain text</returns>
        public static string Decrypt(string privateKey, byte[] encryptedBytes, bool IsOAEPActive)
        {
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaCryptoServiceProvider = null;
            byte[] plainBytes = null;

            try
            {
                cspParams = new CspParameters();
                cspParams.ProviderType = 1;
                rsaCryptoServiceProvider = new RSACryptoServiceProvider(cspParams);
                rsaCryptoServiceProvider.FromXmlString(privateKey);
                //Decryption
                plainBytes = rsaCryptoServiceProvider.Decrypt(encryptedBytes, IsOAEPActive);

                successfullyDecrypted = true;
                return Encoding.Unicode.GetString(plainBytes);
            }
            catch (Exception e)
            {
                successfullyDecrypted = false;
                Debug.WriteLine(e.Source);
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.Data);
                Debug.WriteLine(e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Checks if encryption was successfull
        /// </summary>
        /// <returns></returns>
        public bool IsSuccessfullyEncrypted()
        {
            return successfullyEncrypted;
        }

        /// <summary>
        /// Checks if decryption was successfull
        /// </summary>
        /// <returns></returns>
        public bool IsSuccessfullyDecrypted()
        {
            return successfullyDecrypted;
        }
    }
}