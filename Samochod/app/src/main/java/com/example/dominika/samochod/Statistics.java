package com.example.dominika.samochod;


import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.gson.JsonObject;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;
import com.koushikdutta.ion.Response;
/**
 * Created by Dominika on 04.04.2017.
 */


//KLASA OBSLUGUJACA KAMERKE
public class Statistics extends Fragment {

    private static Context context;
    String url = "http://naszSamochod.com.pl/userStats/addStats";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.statistics, container, false);

        Statistics.context = getContext();

        final EditText km = (EditText) rootView.findViewById(R.id.kilDrivenET);
        final EditText fuel = (EditText) rootView.findViewById(R.id.fuelUsedET);
        final EditText velocity = (EditText) rootView.findViewById(R.id.maxVelocityET);
        final Button send = (Button) rootView.findViewById(R.id.send_stat);

        final JsonObject json = new JsonObject();


        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Double prop1 = new Double(km.getText().toString());
                Double prop2 = new Double(fuel.getText().toString());
                Double prop3 = new Double(velocity.getText().toString());
                json.addProperty("KilometersDriven", prop1);
                json.addProperty("FuelUsed", prop2);
                json.addProperty("MaxVelocity", prop3);

                Ion.with(context)
                        .load(url)
                        .setJsonObjectBody(json)
                        .asJsonObject()
                        .withResponse()
                        .setCallback(new FutureCallback<Response<JsonObject>>() {
                            @Override
                            public void onCompleted(Exception e, Response<JsonObject> result) {
                                System.out.println("KOD BLEDU - STATYSTYKI: "+result.getHeaders().code());
                                if(result.getHeaders().code() == 200)
                                {
                                    System.out.println("Wysłano statystyki");
                                }
                                else
                                {
                                    showErrorToast();
                                }
                            }
                        });
            }
        });

        return rootView;
    }

    private void showErrorToast() {
        Toast.makeText(context, "Nie wysłano statystyk", Toast.LENGTH_SHORT).show();
    }

}