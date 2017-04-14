package com.example.dominika.samochod;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.List;

/**
 * Created by Dominika on 14.04.2017.
 */

public class recycleview_adapter extends RecyclerView.Adapter<recycleview_adapter.ViewHolder> implements View.OnClickListener{

    List<String> mFruiteList;

    public static RecyclerView recyclerView;
    public static class ViewHolder extends RecyclerView.ViewHolder {

        public final View mView;

        public final TextView mTextView;


        public ViewHolder(View view) {
            super(view);
            mView = view;
            //mImageView = (ImageView) view.findViewById(R.id.avatar);
            mTextView = (TextView) view.findViewById(R.id.id_text_view);
            recyclerView = (RecyclerView) view.findViewById(R.id.id_recycleview);
        }
    }



    public recycleview_adapter(List<String> items) {

        mFruiteList = items;
    }


    @Override
    public void onClick(View v) {
        int id = v.getId();
        System.out.print(id);
    }


    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.group_list_item, parent, false);

        view.setOnClickListener(new MyOnClickListener());

        return new ViewHolder(view);
    }

    class MyOnClickListener implements View.OnClickListener {
        @Override
        public void onClick(View v) {
            //RecyclerView recyclerView;
            //recyclerView = (RecyclerView) v.findViewById(R.id.id_recycleview);
            //int itemPosition = recyclerView.getChildLayoutPosition(v);
            //recyclerView = (RecyclerView) v.findViewById(R.id.id_recycleview);
           // int itemPosition = recyclerView.getId();
           // new ViewHolder(v);
           // int itemPosition = recyclerView.getChildLayoutPosition(v);
            //Log.e("Clicked and Position ",String.valueOf(itemPosition));
        }
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {

        holder.mTextView.setText(mFruiteList.get(position));
    }



    @Override
    public int getItemCount() {
        return mFruiteList.size();
    }
}
