package com.example.dominika.samochod;

/**
 * Created by Dominika on 15.04.2017.
 */

import java.security.PrivateKey;
import java.security.PublicKey;

/**
 * Created by msokol on 11.04.17.
 */
public class RSAKeyHolder {
    private static PrivateKey privateKey;
    private static PublicKey publicKey;

    public RSAKeyHolder(PublicKey publicKey, PrivateKey privateKey) {
        this.publicKey = publicKey;
        this.privateKey = privateKey;
    }

    public static PrivateKey getPrivateKey() {
        return privateKey;
    }

    public static void setPrivateKey(PrivateKey privateKey) {
        RSAKeyHolder.privateKey = privateKey;
    }

    public static PublicKey getPublicKey() {
        return publicKey;
    }

    public static void setPublicKey(PublicKey publicKey) {
        RSAKeyHolder.publicKey = publicKey;
    }
}