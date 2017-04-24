package com.example.dominika.samochod;

import org.bouncycastle.asn1.x509.SubjectPublicKeyInfo;
import org.bouncycastle.crypto.AsymmetricCipherKeyPair;
import org.bouncycastle.crypto.KeyGenerationParameters;
import org.bouncycastle.crypto.generators.RSAKeyPairGenerator;
import org.bouncycastle.crypto.params.AsymmetricKeyParameter;
import org.bouncycastle.crypto.prng.RandomGenerator;

import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.SecureRandom;
import java.util.Date;

/**
 * Created by Dominika on 20.04.2017.
 */

public class KeysHolder {

    /*private AsymmetricKeyParameter privateKey;
    public AsymmetricKeyParameter getPrivateKey() {
        return privateKey;
    }

    public void setPrivateKey(AsymmetricKeyParameter privateKey) {
        this.privateKey = privateKey;
    }

    public AsymmetricKeyParameter getPublicKey() {
        return publicKey;
    }

    public void setPublicKey(AsymmetricKeyParameter publicKey) {
        this.publicKey = publicKey;
    }

    private AsymmetricKeyParameter publicKey;

    private Date expirationDate;
    public Date getExpirationDate() {
        return expirationDate;
    }

    public void setExpirationDate(Date expirationDate) {
        this.expirationDate = expirationDate;
    }

    public void GenerateKeys(int keySize)
    {
        RandomGenerator randomGenerator = new RandomGenerator();
        SecureRandom secureRandom = new SecureRandom(randomGenerator);
        KeyGenerationParameters keyGenerationParameters = new KeyGenerationParameters(secureRandom, keySize);

        RSAKeyPairGenerator keyPairGenerator = new RSAKeyPairGenerator();
        keyPairGenerator.init(keyGenerationParameters);
        AsymmetricCipherKeyPair keyPair = keyPairGenerator.generateKeyPair();
        setPrivateKey((AsymmetricKeyParameter) keyPair.getPrivate());
        setPublicKey((AsymmetricKeyParameter) keyPair.getPublic());
    }

    public String SerializeKey()
    {
        SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(PublicKey);
        byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();
        String serializedPublic = Convert.ToBase64String(serializedPublicBytes);
        return serializedPublic;
    }*/
}
