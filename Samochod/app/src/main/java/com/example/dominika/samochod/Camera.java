package com.example.dominika.samochod;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.provider.MediaStore;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;

/**
 * Created by Dominika on 04.04.2017.
 */


//KLASA OBSLUGUJACA KAMERKE
public class Camera extends Fragment {

    private static final int REQUEST_IMAGE_CAPTURE = 1888;
    ImageView image;
    Button button;
    private static final int CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE = 1888;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.camera, container, false);


        button = (Button) rootView.findViewById(R.id.take_photo);
        image = (ImageView) rootView.findViewById(R.id.photo);

        button.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view) {

                Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                startActivityForResult(intent, CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE);
            }

        });
        return rootView;
    }


    //WYSWIETLENIE ZDJECIA W IMAGEVIEW
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == Activity.RESULT_OK) {
            Bundle extras = data.getExtras();
            Bitmap imageBitmap = (Bitmap) extras.get("data");
            image.setImageBitmap(imageBitmap);
        }
    }
}