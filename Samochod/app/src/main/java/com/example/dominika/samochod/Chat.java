package com.example.dominika.samochod;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.Arrays;
import java.util.List;

/**
 * Created by Dominika on 04.04.2017.
 */

//KLASA OBSLUGUJACA CZAT
public class Chat extends Fragment {

    //LISTA GRUP DYSKUSYJNYCH
    public static final String[] chatRow = {"Alfa Romeo","Audi","BMW","Bentley","Daewoo","Dacia","Citroen","Ford",
            "Fiat","Ferrari","Honda","Hyundai","Lancia","Lexus","Mercedes","Seat","Skoda","Porsche","Renault",
            "Toyota","Suzuki","Subaru","Volvo","Volkswagen","Peugeot","Opel","Nissan","Maserati",
            "Mazda","Mitsubishi","Rolls-Royce","Lamborgini","Infiniti","Isuzu","Iveco","Chrystel"};

    //PRZEKONWERTOWANIE ARRAY DO LIST
    List chat_row = Arrays.asList(chatRow);

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        RecyclerView rv = (RecyclerView) inflater.inflate(
                R.layout.chat_list_layout, container, false);

        //rv.setLayoutManager(new LinearLayoutManager(rv.getContext()));
        //rv.setAdapter(new RecycleviewAdapter(chat_row));

        return rv;
    }
}
