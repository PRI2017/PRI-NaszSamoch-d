package com.example.dominika.samochod;

import android.app.Activity;
import android.content.ContentResolver;
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
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

import java.io.File;
import java.net.URI;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Dominika on 04.04.2017.
 */


//KLASA OBSLUGUJACA KAMERKE
public class Camera extends Fragment {

    private static final int REQUEST_IMAGE_CAPTURE = 1888;
    ImageView image;
    Button button;
    private static final int CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE = 1888;
    private Uri mImageUri;//
    String TAG = "cos";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.camera, container, false);


        button = (Button) rootView.findViewById(R.id.take_photo);
        image = (ImageView) rootView.findViewById(R.id.photo);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                /*Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                startActivityForResult(intent, CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE);*/
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

                //intent.putExtra(MediaStore.EXTRA_OUTPUT, mImageUri);
                //startActivityForResult(intent, CAPTURE_IMAGE_ACTIVITY_REQUEST_CODE);

            }

            private File createTemporaryFile(String part, String ext) throws Exception {
                //File outputDir = getContext().getCacheDir(); // context being the Activity pointer
                //File outputFile = File.createTempFile("prefix", "extension", outputDir);

                String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());

                String imageFileName="JPEG_"+timeStamp+".jpg";

                File photo = new File(Environment.getExternalStorageDirectory(),  imageFileName);

                return photo;

                /*File tempDir = Environment.getExternalStorageDirectory();
                tempDir = new File(tempDir.getAbsolutePath() + "/.temp/");
                if (!tempDir.exists()) {
                    tempDir.mkdirs();
                }
                return File.createTempFile(part, ext, tempDir);
                //return outputFile;*/
            }
        });
        return rootView;
    }

    //WYSWIETLENIE ZDJECIA W IMAGEVIEW
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        //super.onActivityResult(requestCode, resultCode, data);

        /*if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == Activity.RESULT_OK) {
            Bundle extras = data.getExtras();
            Bitmap imageBitmap = (Bitmap) extras.get("data");
            image.setImageBitmap(imageBitmap);
        }*/

        if(requestCode == REQUEST_IMAGE_CAPTURE && resultCode == Activity.RESULT_OK)
        {
            this.grabImage(image);
        }
        Intent intent = new Intent("android.media.action.IMAGE_CAPTURE");
        super.onActivityResult(requestCode,resultCode,intent);
    }

    ///////

    public void grabImage(ImageView imageView)
    {
        this.getContext().getContentResolver().notifyChange(mImageUri, null);
        ContentResolver cr = this.getContext().getContentResolver();
        Bitmap bitmap;
        try
        {
            bitmap = android.provider.MediaStore.Images.Media.getBitmap(cr, mImageUri);

            imageView.setImageBitmap(bitmap);
        }
        catch (Exception e)
        {
            //Toast.makeText(this, "Failed to load", Toast.LENGTH_SHORT).show();
            Log.d(TAG, "Failed to load", e);
        }
    }

}