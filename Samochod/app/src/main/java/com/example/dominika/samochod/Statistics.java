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
public class Statistics extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {


        RecyclerView rv = (RecyclerView) inflater.inflate(
                R.layout.statistics, container, false);

        return rv;
    }
}
