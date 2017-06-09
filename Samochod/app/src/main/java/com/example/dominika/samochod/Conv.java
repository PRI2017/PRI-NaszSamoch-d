package com.example.dominika.samochod;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;

import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by Dominika on 27.04.2017.
 */

//KLASA OBSŁUGUJĄCA KONKRETNĄ KONWERSACJĘ - KONKRETNĄ GRUPĘ ROZMÓWCÓW (KONKRETNE FORUM)
public class Conv extends AppCompatActivity {

    String url = "http://naszsamochod.com.pl/groups/mobilegroup";

    ArrayList<ConvUser> arrayOfUsers = new ArrayList<>();

    public ConvUser newUser;
    public ConvAdapter adapter;
    Button send;
    EditText message;
    String message_;
    private static Context context;
    public static List<String> usersList = new ArrayList<>();
    public static List<String> postsList = new ArrayList<>();

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.conversation);
        Conv.context = getApplicationContext();

        final ListView listView = (ListView) findViewById(R.id.latest_posts);
        send = (Button) findViewById(R.id.send_message_button);
        message = (EditText) findViewById(R.id.message_tv);


        //ODBIERANIE NAZWY GRUPY NA KTORA KLIKNELISMY
        Intent intent = getIntent();
        Bundle bd = intent.getExtras();
        if(bd != null)
        {
            final String getName = (String) bd.get("NameOfTheGroup");   //POBIERANIE NAZWY GRUPY NA KTORA KLIKNELISMY
            System.out.println("Wynik: " + getName);
            //ODBIERANIE GRUP Z SERWERA
            Ion.with(context)
                    .load(url)
                    .asJsonArray()
                    .setCallback(new FutureCallback<JsonArray>() {
                        @Override
                        public void onCompleted(Exception e, JsonArray result) {
                            for(int i = 0; i < result.size(); i++) {

                                JsonElement json = result.get(i);
                                JsonObject object = json.getAsJsonObject();

                                String group = object.get("Name").toString();

                                if(group.equals(getName)) {
                                    JsonArray jsonArray = object.getAsJsonArray("LatestPosts");
                                    for (int j = 0; j < jsonArray.size(); j++) {
                                        System.out.println("Rozmiar: " + jsonArray.size());
                                        JsonElement jsonElement = jsonArray.get(j);
                                        JsonObject jsonObject = jsonElement.getAsJsonObject();
                                        JsonElement jsonElement1 = jsonObject.get("Creator");
                                        JsonObject jsonObject1 = jsonElement1.getAsJsonObject();
                                        String name2 = jsonObject1.get("Name").toString();      //UZYSKANIE IMIENIA OSOBY KTORA DODALA POST
                                        String surname = jsonObject1.get("Surname").toString(); //UZYSKANIE NAZWISKA OSOBY KTORA DODALA POST
                                        String resultt = jsonObject.get("Text").toString();     //UZYSKANIE POSTU DODANEGO PRZEZ UZYTKOWNIKA POWYZEJ
                                        System.out.println(resultt);
                                        usersList.add(name2);
                                        postsList.add(resultt);
                                    }
                                }
                            }
                            adapter = new ConvAdapter(context, usersList, postsList);
                            listView.setAdapter(adapter);
                        }
                    });
        }
        ///////////////////////////////////////////////////

        //newUser = new ConvUser("Nathan", "San Diego");
        //adapter =  new ConvAdapter(this, arrayOfUsers);

        //listView.setAdapter(adapter);
        //adapter.add(newUser);

        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                message_ = message.getText().toString();
                arrayOfUsers.add(new ConvUser("COS", message_));
            }
        });
    }

    //CZYSZCZENIE LIST PO KLIKNIECIU WSTECZ
    @Override
    public void onBackPressed() {
        usersList.clear();
        postsList.clear();
        super.onBackPressed();
    }
}
