import javax.crypto.Cipher;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PrivateKey;
import java.security.PublicKey;

/**
 * Created by msokol on 11.04.17.
 */
public class CryptoRSA {

    public static final String ALGORITHM_WITHOUT_PADDING = "RSA";
    public static final String ALGORITHM_WITH_PADDING = "RSA/ECB/OAEPWithSHA-256AndMGF1Padding";

    /***
     * Generates pair of public and private keys
     * to be used in RSA Encryption and Decryption respectively
     * @param keySize
     * @return
     */
    public static RSAKeyHolder generateKeys(int keySize) {
        try {
            PublicKey publicKey;
            PrivateKey privateKey;

            final KeyPairGenerator keyPairGenerator = KeyPairGenerator.getInstance(ALGORITHM_WITHOUT_PADDING);
            keyPairGenerator.initialize(keySize);
            final KeyPair keyPair = keyPairGenerator.generateKeyPair();

            publicKey = keyPair.getPublic();
            privateKey = keyPair.getPrivate();

            return new RSAKeyHolder(publicKey, privateKey);
        } catch (Exception ex) {
            ex.printStackTrace();
            return new RSAKeyHolder(null, null);
        }
    }

    /***
     * Encryption using RSA with or without OAEP padding
     * @param plainText
     * @param publicKey
     * @param isOAEPActive
     * @return
     */
    public static byte[] encrypt(String plainText, PublicKey publicKey, boolean isOAEPActive) {
        byte[] cipherText = null;
        try {
            final Cipher cipher;
            if (!isOAEPActive) {
                cipher = Cipher.getInstance(ALGORITHM_WITHOUT_PADDING);
            } else {
                cipher = Cipher.getInstance(ALGORITHM_WITH_PADDING);
            }
            cipher.init(Cipher.ENCRYPT_MODE, publicKey);
            cipherText = cipher.doFinal(plainText.getBytes());
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return cipherText;
    }

    /***
     * Decryption using RSA with or without OAEP padding
     * @param encryptedBytes
     * @param privateKey
     * @param isOAEPActive
     * @return
     */
    public static String decrypt(byte[] encryptedBytes, PrivateKey privateKey, boolean isOAEPActive){
        byte[] plainText = null;
        try{
            final Cipher cipher;
            if (!isOAEPActive) {
                cipher = Cipher.getInstance(ALGORITHM_WITHOUT_PADDING);
            } else {
                cipher = Cipher.getInstance(ALGORITHM_WITH_PADDING);
            }
            cipher.init(Cipher.DECRYPT_MODE, privateKey);
            plainText = cipher.doFinal(encryptedBytes);
        }catch (Exception ex){
            ex.printStackTrace();
        }
        return new String(plainText);
    }
}
