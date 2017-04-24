package com.example.dominika.samochod;

import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.text.method.LinkMovementMethod;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import com.android.volley.NetworkResponse;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import org.bouncycastle.crypto.InvalidCipherTextException;
import java.io.IOException;
import java.net.CookieHandler;
import java.net.CookieManager;
import java.security.NoSuchAlgorithmException;
import java.security.NoSuchProviderException;


public class LogIn extends AppCompatActivity {

    static final int CAM = 0;
    NetworkResponse errorRes;
    String stringData = "";
    RequestQueue requestQueue;
    String url = "http://localhost:62368/api/login";

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


        logIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(LogIn.this, Toolbar.class);
                /////////////////////////////////////////////////////////////
                //final HashMap<String, String> params = new HashMap<String, String>();

                try {
                    new CryptoRSA().TestEncDec();
                } catch (InvalidCipherTextException e) {
                    e.printStackTrace();
                } catch (NoSuchAlgorithmException e) {
                    e.printStackTrace();
                } catch (NoSuchProviderException e) {
                    e.printStackTrace();
                } catch (IOException e) {
                    e.printStackTrace();
                }

               /* params.put("Email", emailET.getText().toString());
                params.put("Password", passwordET.getText().toString());

                JsonObjectRequest req = new JsonObjectRequest(Request.Method.POST, url, new JSONObject(params),
                        new Response.Listener<JSONObject>() {

                            @Override
                            public void onResponse(JSONObject response) {
                                Log.v("Response:%n %s", response.toString());
                                Log.v("Cookies: $s $n", manager.getCookieStore().toString());

                                Intent intent = new Intent(LogIn.this, Toolbar.class);
                                startActivityForResult(intent, CAM);
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
                odp(req);*/
                //////////////////////////////////////////////////////////////////////////////////////
                startActivityForResult(intent, CAM);
            }
        });
    }

    private void showErrorToast() {
        Toast.makeText(this, R.string.error, Toast.LENGTH_SHORT).show();
    }


    private void odp(JsonObjectRequest postRequest)
    {
        Volley.newRequestQueue(this).add(postRequest);
    }
}
