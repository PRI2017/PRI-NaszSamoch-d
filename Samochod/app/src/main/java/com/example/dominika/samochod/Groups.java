package com.example.dominika.samochod;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
/**
 * Created by Dominika on 04.04.2017.
 */

//KLASA OBSLUGUJACA GRUPY DYSKUSYJNE
//WYSWIETLENIE LISTY GRUP
public class Groups extends Fragment {

    private static Context context;
    String url = "http://naszsamochod.com.pl/groups/mobilegroup";
    public static String resultt;

    //groups/addmobilepost/id_grupy          "Text"



    //LISTA DOSTEPNYCH GROUP
    public static List<String> groupsList = new ArrayList<>();


    @Override
    public View onCreateView(final LayoutInflater inflater, final ViewGroup container,
                             Bundle savedInstanceState) {

        Groups.context = getContext();

        final RecyclerView rv = (RecyclerView) inflater.inflate(
                R.layout.group_list_layout, container, false);

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
                            resultt = object.get("Name").toString();
                            groupsList.add(resultt);
                        }

                        rv.setLayoutManager(new LinearLayoutManager(rv.getContext()));
                        rv.setAdapter(new RecycleviewAdapterGroup(groupsList));
                    }
                });

        return rv;
    }
}
