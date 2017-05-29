package com.example.dominika.samochod;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.method.LinkMovementMethod;
import android.util.Base64;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.JsonObject;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;
import com.koushikdutta.ion.Response;

import org.bouncycastle.crypto.InvalidCipherTextException;
import org.bouncycastle.crypto.params.AsymmetricKeyParameter;
import org.bouncycastle.crypto.util.PublicKeyFactory;

import java.io.IOException;

/**
 * Created by Dominika on 04.05.2017.
 */

public class Login extends AppCompatActivity {
    String url2 = "http://naszsamochod.com.pl/PRI-NaszSamochod/Mobile/Login";
    String url = "http://naszsamochod.com.pl/PRI-NaszSamochod/api/publickey";

    //String url2 = "http://naszsamochod.azurewebsites.net/Mobile/Login";
    //String url = "http://naszsamochod.azurewebsites.net/api/publickey";
    //groups/mobilegroup/id             mobilegroup/id
    //String url2 = "http://192.168.1.184:8080/Mobile/Login";
    //String url = "http://192.168.1.184:8080/api/publickey";
    private static Context context;
    private static String key;
    AsymmetricKeyParameter key2;
    private static byte[] password;
    String password_rsa;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Login.context = getApplicationContext();

        setContentView(R.layout.log_in);

        final EditText emailET = (EditText) findViewById(R.id.email_et);
        final EditText passwordET = (EditText) findViewById(R.id.password_et);
        final Button logIn = (Button) findViewById(R.id.logIn_button);

        //UMOZLIWIENIE KLIKANIA NA LINK ODSYLAJACY DO STRONY Z REJESTRACJA
        TextView mLink;
        mLink = (TextView) findViewById(R.id.link);
        if (mLink != null) {
            mLink.setMovementMethod(LinkMovementMethod.getInstance());
        }
        //////


        logIn.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v) {

                //POBIERANIE KLUCZA
                Ion.with(context)
                .load(url)
                        .asString()
                        .setCallback(new FutureCallback<String>() {
                            @Override
                            public void onCompleted(Exception e, String result) {
                                key = result;
                                try {
                                    key2 = PublicKeyFactory.createKey(Base64.decode(result, Base64.DEFAULT));
                                } catch (IOException e1) {
                                    e1.printStackTrace();
                                } catch (Exception e1) {
                                    e1.printStackTrace();
                                }
                                System.out.println(result);


                                //KODOWANIE KLUCZA I WYSYLANIE JSONA////////////////////////////////////////////
                                JsonObject json = new JsonObject();
                                json.addProperty("Email",  emailET.getText().toString());


                                try {
                                    password_rsa = new String(Base64.encodeToString((CryptoRSA.Encrypt(passwordET.getText().toString(), key2)),Base64.DEFAULT)).replaceAll("\n", "");
                                } catch (InvalidCipherTextException e1) {
                                    e1.printStackTrace();
                                }
                                //dodaje znak \n do json
                                    json.addProperty("Password",password_rsa);
                                    System.out.println(password_rsa);

                                json.addProperty("RememberMe",  "false");

                                Ion.with(context)
                                        .load(url2)
                                        .setJsonObjectBody(json)
                                        .asJsonObject()
                                        .withResponse()
                                        .setCallback(new FutureCallback<Response<JsonObject>>() {
                                            @Override
                                            public void onCompleted(Exception e, Response<JsonObject> result) {
                                                System.out.println("KOD BLEDU: "+result.getHeaders().code());
                                                if(result.getHeaders().code() == 200)
                                                {
                                                    Intent intent = new Intent(Login.this, Toolbar.class);
                                                    startActivity(intent);
                                                }
                                                else
                                                {
                                                    showErrorToast();
                                                }
                                            }
                                        });
                            }
                        });
            }
        });
    }


    //WYSWIETLENIE POSTA PRZY NIEUDANEJ PROBLEM LOGOWANIA
    private void showErrorToast() {
        Toast.makeText(this, R.string.error, Toast.LENGTH_SHORT).show();
    }
}

