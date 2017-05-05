package com.example.dominika.samochod;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.text.method.LinkMovementMethod;
import android.util.Base64;
import android.util.Log;
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
import java.nio.charset.StandardCharsets;

/**
 * Created by Dominika on 04.05.2017.
 */

public class Login2 extends AppCompatActivity {
    String url2 = "http://naszsamochod.azurewebsites.net/Mobile/Login";
    String url = "http://naszsamochod.azurewebsites.net/api/publickey";
    private static Context context;
    private static String key;
    AsymmetricKeyParameter key2;
    private static byte[] password;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Login2.context = getApplicationContext();

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
                                    key2 = PublicKeyFactory.createKey(Base64.decode(key, Base64.DEFAULT));

                                    //KODOWANIE HASLA ZA POMOCA POBRANEGO KLUCZA/////////////////////////////////////////////
                                    password = CryptoRSA.Encrypt(passwordET.getText().toString(), key2);

                                    System.out.println("kluczyk: "+ password);
                                    //convertedPassword =
                                } catch (IOException e1) {
                                    e1.printStackTrace();
                                } catch (InvalidCipherTextException e1) {
                                    e1.printStackTrace();
                                } catch (Exception e1) {
                                    e1.printStackTrace();
                                }
                                System.out.println(result);
                                //System.out.println("KeyOk: " + password);



                                //KODOWANIE KLUCZA I WYSYLANIE JSONA////////////////////////////////////////////
                                JsonObject json = new JsonObject();
                                json.addProperty("Email",  emailET.getText().toString());

                                try {
                                    json.addProperty("Password", String.valueOf(Base64.encodeToString((CryptoRSA.Encrypt(passwordET.getText().toString(), key2)),Base64.DEFAULT)));
                                } catch (InvalidCipherTextException e1) {
                                    e1.printStackTrace();
                                }

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
                                                    Intent intent = new Intent(Login2.this, Toolbar.class);
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
    //WYSWIETLENIE POSTA PRZY NIEUDANEJ PROBIE LOGOWANIA
    private void showErrorToast() {
        Toast.makeText(this, R.string.error, Toast.LENGTH_SHORT).show();
    }
}

