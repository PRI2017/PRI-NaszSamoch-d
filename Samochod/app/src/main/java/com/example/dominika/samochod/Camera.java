package com.example.dominika.samochod;

import android.annotation.TargetApi;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.ContentResolver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.gson.JsonObject;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;
import java.io.File;
import java.io.IOException;
import java.net.URI;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Dominika on 04.04.2017.
 */


//KLASA OBSLUGUJACA KAMERKE
public class Camera extends Fragment {

    String url = "http://naszsamochod.com.pl/galleryphoto/galleryid";
    String url_check = "http://naszsamochod.com.pl/profphoto/upload";
    private static final int REQUEST_IMAGE_CAPTURE = 1888;
    ImageView image;
    Button button;
    Button button2;
    private static final int CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE = 1888;
    private Uri mImageUri;//
    String TAG = "blad";
    File photo;

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

        button = (Button) rootView.findViewById(R.id.take_photo);
        button2 = (Button) rootView.findViewById(R.id.send_photo);
        image = (ImageView) rootView.findViewById(R.id.photo);

        //REAKCJA NA KLIKNIECIE PRZYCISKU ZROB ZDJECIE
        button.setOnClickListener(new View.OnClickListener() {
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

        button2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDialog();
            }
        });

        return rootView;
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

            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        Intent intent = new Intent("android.media.action.IMAGE_CAPTURE");
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
                                .load(url_check)
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
    //////////////////////////////////////////////////////////
}