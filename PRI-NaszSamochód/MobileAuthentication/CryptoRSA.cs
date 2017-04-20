using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using System.Diagnostics;
using System.Text;

namespace PRI_NaszSamochod.MobileAuthentication
{
    /// <summary>
    /// Klasa obsługująca generowanie kluczy, szyfrowanie i deszyfrowanie
    /// </summary>
    public class CryptoRSA
    {
        private static IAsymmetricBlockCipher cipher;

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

        public static byte[] Encrypt(string data, AsymmetricKeyParameter publicKey)
        {
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(data);
            cipher = new RsaEngine();

            cipher.Init(!publicKey.IsPrivate, publicKey);
            return cipher.ProcessBlock(dataBytes, 0, data.Length);
        }

        public static string Decrypt(byte[] dataBytes, AsymmetricKeyParameter privateKey)
        {
            cipher.Init(!privateKey.IsPrivate, privateKey);
            return UTF8Encoding.UTF8.GetString(cipher.ProcessBlock(dataBytes, 0, dataBytes.Length));
        }

        public static void TestEncDec()
        {
            string message = "Hello World!";
            GenerateKeys(2048);
            Debug.WriteLine("Plain message: " + message);
            byte[] cipher = Encrypt(message, KeysHolder.PublicKeyHolder);
            Debug.WriteLine("Encrypted message: " + UTF8Encoding.UTF8.GetString(cipher));
            string deciphered = Decrypt(cipher, KeysHolder.PrivateKeyHolder);
            Debug.WriteLine("Decrypted message: " + deciphered);
        }
    }
}