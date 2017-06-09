package com.example.dominika.samochod;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by Dominika on 28.05.2017.
 */

//KLASA WYSWIETLAJACA DANY POST W DANEJ GRUPIE
public class ConvAdapter extends ArrayAdapter<ConvUser> {
    public ConvAdapter(Context context, ArrayList<ConvUser> users) {
        super(context, 0, users);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        ConvUser conv = getItem(position);

        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.conv_item, parent, false);
        }
        // Lookup view for data population
        TextView tvName = (TextView) convertView.findViewById(R.id.username_tv_conv);
        TextView tvHome = (TextView) convertView.findViewById(R.id.message_tv_conv);
        // Populate the data into the template view using the data object
        tvName.setText(conv.nick);
        tvHome.setText(conv.message);

        return convertView;
    }
}
