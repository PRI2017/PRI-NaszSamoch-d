package com.example.dominika.samochod;
import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.method.LinkMovementMethod;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import com.android.volley.NetworkResponse;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.google.gson.JsonObject;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;
import com.koushikdutta.ion.Response;
import org.bouncycastle.crypto.params.AsymmetricKeyParameter;

/**
 * Created by domi on 6/4/2017.
 */

public class LogIn extends AppCompatActivity{

    NetworkResponse errorRes;
    String stringData = "";
        String url2 = "http://naszsamochod.com.pl/Mobile/Login";

        private static Context context;
        private static String key;
        AsymmetricKeyParameter key2;
        private static byte[] password;
        String password_rsa;


        @Override
        public void onCreate(Bundle savedInstanceState) {
            super.onCreate(savedInstanceState);
            Groups.groupsList.clear();
            Conv.postsList.clear();
            Conv.usersList.clear();

            LogIn.context = getApplicationContext();

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


            logIn.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                                             //POBIERANIE KLUCZA
                   /* Ion.with(context)
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
                                    System.out.println(result);*/

                   if(isOnline()) {
                        //KODOWANIE KLUCZA I WYSYLANIE JSONA////////////////////////////////////////////
                        JsonObject json = new JsonObject();
                        json.addProperty("Email", emailET.getText().toString());

                        //password_rsa = new String(Base64.encodeToString((CryptoRSA.Encrypt(passwordET.getText().toString(), key2)),Base64.DEFAULT)).replaceAll("\n", "");

                        json.addProperty("Password", passwordET.getText().toString());
                        json.addProperty("RememberMe", "false");

                           Ion.with(context)
                                   .load(url2)
                                   .setJsonObjectBody(json)
                                   .asJsonObject()
                                   .withResponse()
                                   .setCallback(new FutureCallback<Response<JsonObject>>() {
                                       @Override
                                       public void onCompleted(Exception e, Response<JsonObject> result) {
                                           System.out.println("KOD BLEDU: " + result.getHeaders().code());
                                           if (result.getHeaders().code() == 200) {
                                               Intent intent = new Intent(LogIn.this, Toolbar.class);
                                               startActivity(intent);
                                           } else {
                                               showErrorToast();
                                           }
                                       }
                                   });
                    }
                    else
                   {
                        showConnectionToast();
                   }
                }

            });
        }


    //WYSWIETLENIE POSTA PRZY NIEUDANEJ PROBLEM LOGOWANIA
    private void showErrorToast() {
        Toast.makeText(this, R.string.error, Toast.LENGTH_SHORT).show();
    }

    private void odp(JsonObjectRequest postRequest)
    {
        Volley.newRequestQueue(this).add(postRequest);
    }


    public boolean isOnline() {
        ConnectivityManager cm =
                (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo netInfo = cm.getActiveNetworkInfo();
        return netInfo != null && netInfo.isConnectedOrConnecting();
    }

    private void showConnectionToast() {
        Toast.makeText(this, "Brak połączenia z internetem", Toast.LENGTH_SHORT).show();
    }


    private void showConnectionErrorToast() {
        Toast.makeText(this, "Błąd połączenia z internetem", Toast.LENGTH_SHORT).show();
    }
}
