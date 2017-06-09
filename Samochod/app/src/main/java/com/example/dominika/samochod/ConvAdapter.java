package com.example.dominika.samochod;

import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.Icon;
import android.os.Build;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Dominika on 28.05.2017.
 */

//KLASA WYSWIETLAJACA DANY POST W DANEJ GRUPIE
public class ConvAdapter extends ArrayAdapter<List> {
    private final Context context;
    private final List<String> messages;
    private final List<String> users;

    public ConvAdapter(Context context, List users, List messages) {
        super(context, -1, users);
        this.messages = messages;
        this.context = context;
        this.users = users;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.conv_item, parent, false);
        }

        TextView tvName = (TextView) convertView.findViewById(R.id.username_tv_conv);
        TextView tvHome = (TextView) convertView.findViewById(R.id.message_tv_conv);
        TextView user = (TextView) convertView.findViewById(R.id.user);
        TextView message = (TextView) convertView.findViewById(R.id.message);
        //ImageView image = (ImageView) convertView.findViewById(R.id.profile_icon_conv);
        //image.setImageResource(R.drawable.group_icon);
        tvName.setTextColor(Color.parseColor("#000000"));
        tvHome.setTextColor(Color.parseColor("#000000"));
        user.setTextColor(Color.parseColor("#000000"));
        message.setTextColor(Color.parseColor("#000000"));

        tvName.setText(users.get(position));
        tvHome.setText(messages.get(position));

        return convertView;
    }
}
