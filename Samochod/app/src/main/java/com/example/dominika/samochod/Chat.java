package com.example.dominika.samochod;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

/**
 * Created by Dominika on 04.04.2017.
 */

//KLASA OBSLUGUJACA CZAT
public class Chat extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.chat, container, false);

        return rootView;
    }
}
