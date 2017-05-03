package com.example.dominika.samochod;

import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.text.method.LinkMovementMethod;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import com.android.volley.NetworkResponse;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.bouncycastle.asn1.crmf.PKIPublicationInfo;
import org.bouncycastle.crypto.InvalidCipherTextException;
import org.bouncycastle.crypto.params.AsymmetricKeyParameter;
import org.bouncycastle.crypto.util.PublicKeyFactory;
import org.json.JSONObject;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.CookieHandler;
import java.net.CookieManager;
import java.security.NoSuchAlgorithmException;
import java.security.NoSuchProviderException;
import java.util.HashMap;


public class LogIn extends AppCompatActivity {

    static final int CAM = 0;
    NetworkResponse errorRes;
    String stringData = "";
    RequestQueue requestQueue;
    static String key;
    String url2 = "http://naszsamochod.azurewebsites.net/Mobile/Login";
    String url = "http://naszsamochod.azurewebsites.net/api/publickey";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.log_in);

        final CookieManager manager = new CookieManager();
        CookieHandler.setDefault( manager  );

        requestQueue = Volley.newRequestQueue(this);

        final EditText emailET = (EditText) findViewById(R.id.email_et);
        final EditText passwordET = (EditText) findViewById(R.id.password_et);
        final Button logIn = (Button) findViewById(R.id.logIn_button);

        final StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);


        //UMOZLIWIENIE KLIKANIA NA LINK ODSYLAJACY DO STRONY Z REJESTRACJA
        TextView mLink;
        mLink = (TextView) findViewById(R.id.link);
        if (mLink != null) {
            mLink.setMovementMethod(LinkMovementMethod.getInstance());
        }
        //////

        //ODEBRANIE KLUCZA Z SERWERA
        logIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                /////////////////////////////////////////////////////////////
                StringRequest req = new StringRequest(Request.Method.GET, url,
                        new Response.Listener<String>() {

                            @Override
                            public void onResponse(String response) {
                                Log.v("Response:%n %s", response.toString());
                                //Log.v("Cookies: $s $n", manager.getCookieStore().toString());

                                key = response.toString();

                                try {
                                    new CryptoRSA().TestEncDec(key);
                                } catch (InvalidCipherTextException e) {
                                    e.printStackTrace();
                                } catch (NoSuchProviderException e) {
                                    e.printStackTrace();
                                } catch (NoSuchAlgorithmException e) {
                                    e.printStackTrace();
                                } catch (IOException e) {
                                    e.printStackTrace();
                                }
                                //USUNAC
                                //Intent intent = new Intent(LogIn.this, Toolbar.class);
                                //startActivityForResult(intent, CAM);
                            }
                        }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        errorRes = error.networkResponse;
                        if (errorRes != null && errorRes.data != null) {
                            try {
                                stringData = new String(errorRes.data, "UTF-8");
                                showErrorToast();
                            } catch (UnsupportedEncodingException e) {
                                e.printStackTrace();
                            }
                        }
                        Log.e("Error", stringData);
                    }
                });
                odp(req);

                //WYSLANIE POSTA NA SERWER Z EMAIL I HASLEM
                final HashMap<String, String> params = new HashMap<String, String>();

                AsymmetricKeyParameter key2 = null;
                try {
                    //NAPRAWIC BO KEY NEI JEST WIDOCZNY W TYM MIEJSCU
                    key2 = PublicKeyFactory.createKey(Base64.decode(key, Base64.DEFAULT));
                } catch (IOException e) {
                    e.printStackTrace();
                }

                try {
                    CryptoRSA.Encrypt(passwordET.getText().toString(),key2);
                } catch (InvalidCipherTextException e) {
                    e.printStackTrace();
                }
                params.put("Email", emailET.getText().toString());
                params.put("Password", passwordET.getText().toString());
                params.put("RememberMe", "false");


                JsonObjectRequest req2 = new JsonObjectRequest(Request.Method.POST, url2, new JSONObject(params),
                        new Response.Listener<JSONObject>() {

                            @Override
                            public void onResponse(JSONObject response) {
                                Log.v("Response:%n %s", response.toString());

                                //DODAC PO WPROWADZENIU ODPOWIEDNIEGO REQUEST
                                Intent intent = new Intent(LogIn.this, Conversation.class);
                                startActivity(intent);
                            }
                        }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {
                        errorRes = error.networkResponse;
                        if (errorRes != null && errorRes.data != null) {
                            try {
                                stringData = new String(errorRes.data, "UTF-8");
                                showErrorToast();
                            } catch (UnsupportedEncodingException e) {
                                e.printStackTrace();
                            }
                            Log.e("Error", stringData);
                        }
                    }
                });
                odp2(req2);
            }
        });
    }

    //WYSWIETLENIE POSTA PRZY NIEUDANEJ PROBIE LOGOWANIA
    private void showErrorToast() {
        Toast.makeText(this, R.string.error, Toast.LENGTH_SHORT).show();
    }


    //STRING REQUEST
    private void odp(StringRequest postRequest)
    {
        Volley.newRequestQueue(this).add(postRequest);
    }

    //JSON REQUEST
    private void odp2(JsonObjectRequest postRequest)
    {
        Volley.newRequestQueue(this).add(postRequest);
    }

   /* public AsymmetricKeyParameter DeserializePublicKey(String serializedKey)
    {
        //return PublicKeyFactory.
        //return PublicKeyFactory.CreateKey(Convert.FromBase64String(serializedKey));
    }*/
}
