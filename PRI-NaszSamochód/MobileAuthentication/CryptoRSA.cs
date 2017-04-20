using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
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
        /// Generating private and public keys for RSA algorithm with size = <code>keySize</code>
        /// </summary>
        /// <param name="keySize"></param>
        public static void GenerateKeys(int keySize)
        {
            CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
            SecureRandom secureRandom = new SecureRandom(randomGenerator);
            var keyGenerationParameters = new KeyGenerationParameters(secureRandom, keySize);

            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            var keyPair = keyPairGenerator.GenerateKeyPair();
            KeysHolder.PrivateKeyHolder = keyPair.Private;
            KeysHolder.PublicKeyHolder = keyPair.Public;
        }

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
        public static void TestEncDec()
        {
            string message = "1111111111111";
            GenerateKeys(1024);
            Debug.WriteLine("Plain message: " + message);


            byte[] cipher = Encrypt(message, KeysHolder.PublicKeyHolder);
            string cstring = Convert.ToBase64String(cipher);
            Debug.WriteLine("Encrypted message: " + cstring);
            byte[] cbytes = Convert.FromBase64String(cstring);
            //if (Array.Equals(cipher, cbytes))
            //{
                string deciphered = Decrypt(cipher, KeysHolder.PrivateKeyHolder);
                Debug.WriteLine("Decrypted message: " + deciphered);
            //}
            //else
            //{
            //    Debug.WriteLine("Error");
            //}
       
        }
    }
}