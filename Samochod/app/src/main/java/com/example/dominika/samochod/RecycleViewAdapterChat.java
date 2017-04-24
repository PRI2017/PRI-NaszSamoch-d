package com.example.dominika.samochod;

import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.List;

/**
 * Created by Dominika on 24.04.2017.
 */

//KLASA DO RENDERWONIA ELEMENTOW LISTY
public class RecycleViewAdapterChat extends RecyclerView.Adapter<RecycleViewAdapterChat.ViewHolder> {

    List<String> chatList;

    public static RecyclerView recyclerView;

    private static final String TAG = "MyActivity";


    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener{

        public final View mView;

        public final TextView username;

        public final TextView message;

        private String mItem;

        public void setItem(String item) {
            mItem = item;
            username.setText(item);
            message.setText(item);
        }

        public ViewHolder(View view) {
            super(view);
            mView = view;
            username = (TextView) view.findViewById(R.id.username_tv);
            recyclerView = (RecyclerView) view.findViewById(R.id.id_recycleview_chat);
            message = (TextView) view.findViewById(R.id.message_tv);
            view.setOnClickListener(this);
        }

        //KLIKANIE NA GRUPE I WYPISYWANIE NAZWY GRUPY W KONSOLI
        @Override
        public void onClick(View v) {
            Log.d(TAG, "onClick " + getPosition() + " " + mItem);
            System.out.println(mItem);
            //ANIMACJA NA ITEM W RECYCLERVIEW
            v.animate().rotationX(360);
        }
    }


    public RecycleViewAdapterChat(List<String> items) {
        chatList = items;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.chat_row, parent, false);

        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {
        //holder.mTextView.setText(groupList.get(position));
        holder.setItem(chatList.get(position));
    }


    @Override
    public int getItemCount() {
        return chatList.size();
    }
}

