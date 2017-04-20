using Org.BouncyCastle.Crypto;

namespace PRI_NaszSamochod.MobileAuthentication
{
    public static class KeysHolder
    {
        public static AsymmetricKeyParameter PrivateKeyHolder { get; set; }
        public static AsymmetricKeyParameter PublicKeyHolder { get; set; }
    }
}