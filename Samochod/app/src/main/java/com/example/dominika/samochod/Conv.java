package com.example.dominika.samochod;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;

/**
 * Created by Dominika on 27.04.2017.
 */

//KLASA OBSŁUGUJĄCA KONKRETNĄ KONWERSACJĘ - KONKRETNĄ GRUPĘ ROZMÓWCÓW (KONKRETNE FORUM)
public class Conv extends AppCompatActivity {
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.conversation);
    }
}
