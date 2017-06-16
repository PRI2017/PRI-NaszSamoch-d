package com.example.dominika.samochod;

import android.app.Activity;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.util.SparseIntArray;
import android.view.View;

/**
 * Created by domi on 6/14/2017.
 */

public class Permission extends Activity {
    private SparseIntArray mErrorString;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mErrorString = new SparseIntArray();

    }

    public void onPermissionGranted(int requestCode) {

    }

    public void requestAppPermission(final String[] requestPermission, final int stringId, final int requestCode){
        mErrorString.put(requestCode, stringId);

        int permissionCheck = PackageManager.PERMISSION_GRANTED;
        boolean showRequestPermission = false;
        for(String permission: requestPermission){
            permissionCheck = permissionCheck + ContextCompat.checkSelfPermission(this, permission);
            showRequestPermission = showRequestPermission || ActivityCompat.shouldShowRequestPermissionRationale(this,permission);
        }

        if (permissionCheck!=PackageManager.PERMISSION_GRANTED)
        {
            if(showRequestPermission)
            {
                Snackbar.make(findViewById(android.R.id.content), stringId, Snackbar.LENGTH_INDEFINITE).setAction("GRANT", new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        //ActivityCompat.requestPermissions(AbsRuntimePermission.this, requestPermission, requestCode);
                    }
                }).show();
            }
        }
    }
}
