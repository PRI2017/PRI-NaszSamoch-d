package com.example.dominika.samochod;

import android.Manifest;
import android.annotation.TargetApi;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.ContentResolver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.provider.Settings;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewTreeObserver;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;
import com.koushikdutta.ion.Response;

import java.io.File;
import java.io.IOException;
import java.net.URI;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by Dominika on 04.04.2017.
 */


//KLASA OBSLUGUJACA KAMERKE
public class Camera extends Fragment {
    String url_profile = "http://naszsamochod.com.pl/profphoto/upload";
    String url_getGalleries = "http://naszsamochod.com.pl/mobile/UserGalleries";
    private static final int REQUEST_IMAGE_CAPTURE = 1888;
    ImageView image;
    Button takePhoto;
    Button sendProfile;
    Button sendToGallery;
    String id_gallery;
    String name_gallery;
    private static final int CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE = 1888;
    private Uri mImageUri;//
    String TAG = "blad";
    File photo;
    String[] galleries_names;
    String[] id_galleries;
    Map<String, String> galleries = new HashMap<>();

    private Context mContext;
    @Override
    public void onAttach(final Activity activity) {
        super.onAttach(activity);
        mContext = activity;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.camera, container, false);

        takePhoto = (Button) rootView.findViewById(R.id.take_photo);
        sendProfile = (Button) rootView.findViewById(R.id.send_profile);        //USTAWIENIE ZDJECIA PROFILOWEGO
        image = (ImageView) rootView.findViewById(R.id.photo);
        sendToGallery = (Button) rootView.findViewById(R.id.send_photo);        //WYSLANIE ZDJECIA DO WYBRANEJ GALERII


        //ODBIERANIE NAZW DOSTEPNYM GALERII Z SERWERA
        Ion.with(mContext)
                .load(url_getGalleries)
                .asJsonArray()
                .setCallback(new FutureCallback<JsonArray>() {
                    @Override
                    public void onCompleted(Exception e, JsonArray result) {
                        galleries_names = new String[result.size()];
                        id_galleries = new String[result.size()];
                        for(int i = 0; i < result.size(); i++) {
                            JsonElement json = result.get(i);
                            JsonObject object = json.getAsJsonObject();
                            name_gallery = object.get("name").toString();
                            id_gallery = object.get("id").toString();
                            galleries.put(name_gallery,id_gallery);
                            //list_galleries.add(name_gallery);
                            galleries_names[i] = name_gallery;
                            System.out.println(galleries_names[i]);
                            id_galleries[i] = id_gallery;
                        }
                    }
                });


        //REAKCJA NA KLIKNIECIE PRZYCISKU ZROB ZDJECIE
        takePhoto.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                try {

                    File photo;
                    photo = this.createTemporaryFile("picture", ".jpg");
                    //photo.delete();
                    mImageUri = Uri.fromFile(photo);
                    intent.putExtra(MediaStore.EXTRA_OUTPUT, mImageUri);
                    startActivityForResult(intent, CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE);
                } catch (Exception e) {
                    Log.v(TAG, "Can't create file to take picture!");
                }
            }

            //TWORZENIE PLIKU TYMCZASOWEGO
            private File createTemporaryFile(String part, String ext) throws Exception {

                String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
                String imageFileName="JPEG_"+timeStamp+".jpg";
                photo = new File(Environment.getExternalStorageDirectory(),  imageFileName);

                return photo;
            }
        });

        //WYSLANIE ZDJECIA PROFILOWEGO
        sendProfile.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDialog();
            }
        });

        //WYSLANIE ZDJECIA DO GALERII WYBRANEJ PRZEZ UZYTKOWNIKA
        sendToGallery.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(photo!=null) {
                    showAllert(galleries_names);
                }
                else
                {
                    showToast();
                }
            }
        });
        return rootView;
    }


    //WYSWIETLENIE LISTY DOSTEPNYCH GALERII I WYSLANIE ZDJECIA DO WYBRANEJ PRZEZ UZYTKOWNIKA GALERII
    private void showAllert(final CharSequence[] tab) {
        final String[] url_sendPhotoGallery = {"http://naszsamochod.com.pl/mobile/UploadPhoto?galleryId="};
        System.out.println(tab[0]);
        AlertDialog.Builder builder = new AlertDialog.Builder(mContext);
        builder.setTitle("Wybierz galerię");
        builder.setItems(tab, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int item) {
                System.out.println("Tablica: " + tab[item]);
                System.out.println("Wybrales : " + item);
                String id = id_galleries[item];
                url_sendPhotoGallery[0] = url_sendPhotoGallery[0] + id;
                System.out.println("Url: " + url_sendPhotoGallery[0]);

                Ion.with(mContext)
                        .load(url_sendPhotoGallery[0])
                        .asJsonObject()
                        .withResponse()
                        .setCallback(new FutureCallback<Response<JsonObject>>() {
                            @Override
                            public void onCompleted(Exception e, Response<JsonObject> result) {
                                System.out.println("KOD WYSLANIA ZDJECIA NA SERWER: " + result.getHeaders().code());
                                if (result.getHeaders().code() == 200) {
                                    System.out.println("Wyslano");
                                }
                            }
                        });
            }
        });
        AlertDialog alert = builder.create();
        alert.show();
    }


    //WYSWIETLENIE ZDJECIA W IMAGEVIEW
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {

        if(requestCode == REQUEST_IMAGE_CAPTURE && resultCode == Activity.RESULT_OK)
        {
            ContentResolver cr = this.getContext().getContentResolver();
            Bitmap bitmap;

            if (shouldAskPermissions()) {
                askPermissions();
            }
            try {
                bitmap = MediaStore.Images.Media.getBitmap(cr, mImageUri);
                image.setImageBitmap(bitmap);
                image.setImageBitmap(Bitmap.createScaledBitmap(bitmap,400,500,false));      //ZMIANA WIELKOSCI ZDJECIA

            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        Intent intent = new Intent("android.media.action.IMAGE_CAPTURE");
       // intent.setAction(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
        super.onActivityResult(requestCode,resultCode,intent);
    }


    //DLA NOWSZYCH WERSJI ANDROIDA
    protected boolean shouldAskPermissions() {
        return (Build.VERSION.SDK_INT > Build.VERSION_CODES.LOLLIPOP_MR1);
    }

    @TargetApi(23)
    protected void askPermissions() {
        String[] permissions = {
                "android.permission.READ_EXTERNAL_STORAGE",
                "android.permission.WRITE_EXTERNAL_STORAGE"
        };
        int requestCode = 200;
        requestPermissions(permissions, requestCode);
    }
    //////////////////////////////////////////////////////////////

    /////////////OKIENKO DIALOG - POTWIERDZENIE WYSLANIA ZDJECIA/////////////
    private void showDialog() {
        if (photo!=null) {
            AlertDialog.Builder builder;
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
                builder = new AlertDialog.Builder(mContext, android.R.style.Theme_Material_Dialog_Alert);
            } else {
                builder = new AlertDialog.Builder(mContext);
            }

            builder.setMessage(R.string.send_photo_info)
                    .setTitle(R.string.send_title);

            builder.setPositiveButton(android.R.string.ok, new DialogInterface.OnClickListener() {

                @Override
                public void onClick(DialogInterface dialog, int which) {


                        //WYSYLANIE ZDJECIA NA SERWER
                        Ion.with(Camera.this)
                                .load(url_profile)
                                .setMultipartFile("UploadForm[imageFiles]", photo.getName(), photo)
                                .asJsonObject()
                                .setCallback(new FutureCallback<JsonObject>() {
                                    @Override
                                    public void onCompleted(Exception e, JsonObject result) {
                                    }
                                });
                }
            });

            builder.setNegativeButton(android.R.string.cancel, new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                }
            });
            AlertDialog dialog = builder.create();
            dialog.show();
        }
        else
        {
            showToast();
        }
    }
    //////////////////////////////////////////////////////////



    private void showToast() {
        Toast.makeText(mContext, "Zrob zdjecie", Toast.LENGTH_SHORT).show();
    }
}