using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Diagnostics;
using System.Text;

namespace PRI_NaszSamochod.MobileAuthentication
{
    /// <summary>
    /// Class handling encryption and decryption for authentication with mobile app
    /// </summary>
    public class CryptoRSA
    {

        private static IAsymmetricBlockCipher cipher;
        private static UTF8Encoding encoding = new UTF8Encoding();

        /// <summary>
        /// Encryption using rsa public key
        /// </summary>
        /// <param name="data"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static byte[] Encrypt(string data, AsymmetricKeyParameter publicKey)
        {
            byte[] dataBytes = encoding.GetBytes(data);
            cipher = new RsaEngine();

            cipher.Init(!publicKey.IsPrivate, publicKey);
            byte[] encryptedBytes = cipher.ProcessBlock(dataBytes, 0, data.Length);

            return encryptedBytes;
        }

        /// <summary>
        /// Decryption using rsa private key
        /// </summary>
        /// <param name="dataBytes"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string Decrypt(byte[] dataBytes, AsymmetricKeyParameter privateKey)
        {
            cipher.Init(!privateKey.IsPrivate, privateKey);
            Debug.WriteLine(cipher.GetInputBlockSize());
            byte[] decipheredBytes = cipher.ProcessBlock(dataBytes, 0, dataBytes.Length);
            return encoding.GetString(decipheredBytes);
        }

        /// <summary>
        /// Testing encryption and decryption
        /// </summary>
        //public static void TestEncDec()
        //{

        //    string message = "1111111111111";
        //    KeysHolder kh = new KeysHolder();
        //    kh.GenerateKeys(2048);
        //    Debug.WriteLine("Plain message: " + message);

        //    byte[] cipher = Encrypt(message, kh.PublicKey);
        //    string cstring = Convert.ToBase64String(cipher);
        //    Debug.WriteLine("Encrypted message: " + cstring);
        //    byte[] cbytes = Convert.FromBase64String(cstring);
        //    //if (Array.Equals(cipher, cbytes))
        //    //{
        //    string deciphered = Decrypt(cbytes, kh.PrivateKey);
        //    Debug.WriteLine("Decrypted message: " + deciphered);
        //    //}
        //    //else
        //    //{
        //    //    Debug.WriteLine("Error");
        //    //}

        //}
    }
}