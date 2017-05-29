package com.example.dominika.samochod;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by Dominika on 27.04.2017.
 */

//KLASA OBSŁUGUJĄCA KONKRETNĄ KONWERSACJĘ - KONKRETNĄ GRUPĘ ROZMÓWCÓW (KONKRETNE FORUM)
public class Conv extends AppCompatActivity {

    // Construct the data source
    ArrayList<ConvUser> arrayOfUsers = new ArrayList<>();
    // Create the adapter to convert the array to views
    public ConvUser newUser;
    public ConvAdapter adapter;
    Button send;
    EditText message;
    String message_;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.conversation);

        ListView listView = (ListView) findViewById(R.id.latest_posts);
        send = (Button) findViewById(R.id.send_message_button);
        message = (EditText) findViewById(R.id.message_tv);

        newUser = new ConvUser("Nathan", "San Diego");
        adapter =  new ConvAdapter(this, arrayOfUsers);

        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                message_ = message.getText().toString();
                arrayOfUsers.add(new ConvUser("COS", message_));
            }
        });

        listView.setAdapter(adapter);
        adapter.add(newUser);
    }
}
