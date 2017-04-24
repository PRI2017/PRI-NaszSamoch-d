package com.example.dominika.samochod;

import android.util.Base64;

import org.bouncycastle.crypto.AsymmetricBlockCipher;
import org.bouncycastle.crypto.AsymmetricCipherKeyPair;
import org.bouncycastle.crypto.InvalidCipherTextException;
import org.bouncycastle.crypto.KeyGenerationParameters;
import org.bouncycastle.crypto.engines.RSAEngine;
import org.bouncycastle.crypto.generators.RSAKeyPairGenerator;
import org.bouncycastle.crypto.params.AsymmetricKeyParameter;
import org.bouncycastle.crypto.params.RSAKeyGenerationParameters;
import org.bouncycastle.crypto.prng.RandomGenerator;
import org.bouncycastle.crypto.util.PrivateKeyFactory;
import org.bouncycastle.crypto.util.PublicKeyFactory;

import java.io.IOException;
import java.nio.charset.Charset;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.security.NoSuchProviderException;
import java.security.SecureRandom;
import java.security.Security;

/**
 * Created by Dominika on 20.04.2017.
 */
public class CryptoRSA {

    private static AsymmetricBlockCipher cipher;
    private static Charset charset = Charset.forName("UTF8");

    private AsymmetricKeyParameter publicKey;
    private void setPublicKey(AsymmetricKeyParameter publicKey) {
        this.publicKey = publicKey;
    }
    private AsymmetricKeyParameter getPublicKey() {
        return publicKey;
    }

    public static byte[] Encrypt(String data, AsymmetricKeyParameter publicKey) throws InvalidCipherTextException {
        cipher = new RSAEngine();
        byte[] dataBytes = data.getBytes(charset);
        cipher.init(!publicKey.isPrivate(), publicKey);
        byte[] encryptedBytes = cipher.processBlock(dataBytes, 0, data.length());
        return encryptedBytes;
    }

    public static String Decrypt(byte[] dataBytes, AsymmetricKeyParameter privateKey) throws InvalidCipherTextException {
        cipher.init(!privateKey.isPrivate(), privateKey);
        System.err.println(cipher.getInputBlockSize());
        byte[] decipheredBytes = cipher.processBlock(dataBytes, 0, dataBytes.length);
        return new String(decipheredBytes, charset);
    }

    private AsymmetricKeyParameter privateKey;
    public AsymmetricKeyParameter getPrivateKey() {
        return privateKey;
    }

    public void setPrivateKey(AsymmetricKeyParameter privateKey) {
        this.privateKey = privateKey;
    }

    /*private void GenerateKeys(int keySize) throws NoSuchProviderException, NoSuchAlgorithmException {
        Security.addProvider(new org.bouncycastle.jce.provider.BouncyCastleProvider());
        SecureRandom secureRandom = new SecureRandom();
       // RSAKeyGenerationParameters keyGenerationParameters = new RSAKeyGenerationParameters(getPublicKey(). ,secureRandom, keySize, keySize);

        String key;
        key="";
        PublicKeyFactory.createKey(android.util.Base64.decode());
        KeyPairGenerator keyPairGenerator = KeyPairGenerator.getInstance("RSA", "BC");
        keyPairGenerator.initialize(keySize, secureRandom);
        KeyPair keyPair = keyPairGenerator.generateKeyPair();
        setPrivateKey((AsymmetricKeyParameter) keyPair.getPrivate());
        setPublicKey((AsymmetricKeyParameter) keyPair.getPublic());
    }
*/

    public void TestEncDec() throws InvalidCipherTextException, NoSuchProviderException, NoSuchAlgorithmException, IOException {
        String message = "1111111111111";
        //GenerateKeys(2048);

        String pubkey;
        String privkey;
        privkey="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";
        pubkey="MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEAh0avQc8JYAZ/CMMDQY1tUp4cop4z+Ruy6OL/u2LHr700uOP3XSBBTSKOeP2rexFW31rGJz8Dq/xU1NK5ZKl/TGJDJ7YHmcSJKsrIsJU1GGX+6XXAjaBYa7q7b4ekETop/zUbTmHbncsAduhfnekjIIafkakhxWDBTu2lZV4TJoDdkkhdqRTQeQxf7gPWJO1LLc11kMTpPcm1PC3XPnC2tJ/7+UJ+/D2xaQbCOU5wg6kP1U2sOs3hOSY2q8H+hDD80dPrMbvNbq0qPEzGra4vcozoLhT3Hz5rNLV8yqSZsbhE1KmPkPtYXAf4WOGn+NJnKACT0tDNmFdtbM4fWJfHqAu9wiXCnHgPxqtaozeOxLcJ21ib1Z3MWWbnwaTGMRVOf6UjI1icKB9tR2oVIA/kVPEoR/eWbPoO9B+vaiLJasdbVxNx0Nlh5huF17ShX8jcyzj7i8d5MsrckMcKZlGSEOe2PgHzEdbvCo0jGTJQey/tnPN6snJQLN47tZumHlC+KmVk8n7LfMMiQYkH+kJ8UDoW34fa4N/C7oR38X6HCH7OKErkl4qXGFA7A6wjN1RTlMCIK5ktIEWRNdS8kVe2WaLWhO/mlpU0w3CtYC5jWztbFy4IUh/1+I7Vg2IMXRzwRFn12cEE11CZ+/EqECDC0hWiYvjGB2eWZ9LRWiNatxsCAwEAAQ==";
        publicKey = PublicKeyFactory.createKey(android.util.Base64.decode(pubkey, Base64.DEFAULT));
        System.out.println("Plain message: " + message);

        privateKey = PrivateKeyFactory.createKey(android.util.Base64.decode(privkey, Base64.DEFAULT));

        byte[] cipher = Encrypt(message, getPublicKey());

        //String cstring = android.util.Base64.encodeToString(cipher, android.util.Base64.DEFAULT);
        System.out.println("Encrypted message: " + cipher);

        //byte[] cbytes = android.util.Base64.decode(cipher, android.util.Base64.DEFAULT);

        String deciphered = Decrypt(cipher, getPrivateKey());
        System.out.println("Decrypted message: " + deciphered);
    }
}
