package com.example.dominika.samochod;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.ListFragment;
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

public class Conversation extends Fragment {

    public static final String[] FruiteList = {"Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate","Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate","Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate","Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate","Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate","Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate",
            "Apple", "Orange", "Mango", "Grapes", "Jackfruit","pomegranate"};

    //convert array to list
    List fruiteslist = Arrays.asList(FruiteList);


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        /*View rootView = inflater.inflate(R.layout.conversation, container, false);

        return rootView;*/

        RecyclerView rv = (RecyclerView) inflater.inflate(
                R.layout.group_list_layout, container, false);

        rv.setLayoutManager(new LinearLayoutManager(rv.getContext()));

        rv.setAdapter(new recycleview_adapter(fruiteslist));

        return rv;
    }
}
