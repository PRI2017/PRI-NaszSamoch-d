using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using System;

namespace PRI_NaszSamochod.MobileAuthentication
{
    public class KeysHolder
    {
        private AsymmetricKeyParameter privateKeyHolder;

        public AsymmetricKeyParameter PrivateKey
        {
            get { return privateKeyHolder; }
            set { privateKeyHolder = value; }
        }

        private AsymmetricKeyParameter publicKeyHolder;

        public AsymmetricKeyParameter PublicKey
        {
            get { return publicKeyHolder; }
            set { publicKeyHolder = value; }
        }


        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Generating private and public keys for RSA algorithm with size = <code>keySize</code>
        /// </summary>
        /// <param name="keySize"></param>
        public void GenerateKeys(int keySize)
        {
            CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
            SecureRandom secureRandom = new SecureRandom(randomGenerator);
            var keyGenerationParameters = new KeyGenerationParameters(secureRandom, keySize);

            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            var keyPair = keyPairGenerator.GenerateKeyPair();
            PrivateKey = keyPair.Private;
            PublicKey = keyPair.Public;
        }
    }
}