package com.example.dominika.samochod;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.List;

/**
 * Created by Dominika on 14.04.2017.
 */


//KLASA DO RENDERWONIA ELEMENTOW LISTY
public class RecycleviewAdapterGroup extends RecyclerView.Adapter<RecycleviewAdapterGroup.ViewHolder> {

    List<String> groupList;

    public static RecyclerView recyclerView;

    private static final String TAG = "MyActivity";


    public static class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener{

        public final View mView;

        public final TextView mTextView;

        private final Context context;

        private String mItem;

        public void setItem(String item) {
            mItem = item;
            mTextView.setText(item);
        }

        public ViewHolder(View view) {
            super(view);
            mView = view;
            mTextView = (TextView) view.findViewById(R.id.name_of_group_tv);
            recyclerView = (RecyclerView) view.findViewById(R.id.id_recycleview);
            context = view.getContext();
            view.setOnClickListener(this);
        }

        //KLIKANIE NA GRUPE I WYPISYWANIE NAZWY GRUPY W KONSOLI
        @Override
        public void onClick(View v) {
            Log.d(TAG, "onClick " + getPosition() + " " + mItem);
            System.out.println(mItem);
            //ANIMACJA NA ITEM W RECYCLERVIEW
            v.animate().rotationX(360);

            Groups group = new Groups();
            List<String> cos = group.groupsList;
            System.out.println("Wynik: " + cos.get(getPosition()));
            Intent intent = null;

            intent =  new Intent(context, Conv.class);
            intent.putExtra("NameOfTheGroup", cos.get(getPosition()));

            context.startActivity(intent);

        }
    }


    public RecycleviewAdapterGroup(List<String> items) {
        groupList = items;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.group_list_item, parent, false);

        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {
        //holder.mTextView.setText(groupList.get(position));
        holder.setItem(groupList.get(position));
    }


    @Override
    public int getItemCount() {
        return groupList.size();
    }
}