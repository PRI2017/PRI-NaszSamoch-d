package com.example.dominika.samochod;

import android.app.Activity;
import android.content.pm.ActivityInfo;
import android.content.res.Configuration;
import android.support.design.widget.AppBarLayout;
import android.support.design.widget.TabLayout;
import android.support.v7.app.AppCompatActivity;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.os.Bundle;
import android.widget.LinearLayout;

public class MainActivity extends AppCompatActivity {

    private SectionsPagerAdapter mSectionsPagerAdapter;

    private ViewPager mViewPager;

    private TabLayout tabLayout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

       // if(getResources().getConfiguration().orientation == Configuration.ORIENTATION_PORTRAIT) {
            setContentView(R.layout.toolbar);

            mSectionsPagerAdapter = new SectionsPagerAdapter(getSupportFragmentManager());

            //setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
            mViewPager = (ViewPager) findViewById(R.id.container);
            mViewPager.setAdapter(mSectionsPagerAdapter);
            mViewPager.setOffscreenPageLimit(3);

            tabLayout = (TabLayout) findViewById(R.id.tabs);
            tabLayout.setupWithViewPager(mViewPager);

            setTabLayout();
       /* }
        else
        {
            setContentView(R.layout.toolbar);
            AppBarLayout appbar = (AppBarLayout) findViewById(R.id.appbar);
           // setTabLayout();
            //appbar.setOrientation(AppBarLayout.HORIZONTAL);
            //setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        }*/
    }

   // if(getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE){
    //USTAWIENIE IKON
    private void setTabLayout(){
        tabLayout.getTabAt(0).setIcon(R.drawable.group_icon);
        tabLayout.getTabAt(1).setIcon(R.drawable.chat_icon);
        tabLayout.getTabAt(2).setIcon(R.drawable.camera_icon);
    }


    //PRZELACZANIE MIEDZY ZAKLADKAMI
    public class SectionsPagerAdapter extends FragmentPagerAdapter {

        public SectionsPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {

            Fragment fragment = null;
            switch(position){
                case 0:
                    fragment = new Conversation();
                    break;
                case 1:
                    fragment = new Chat();
                    break;
                case 2:
                    fragment = new Camera();
                    break;
                default:
                    return null;
            }
            return fragment;
        }

        @Override
        public int getCount() {
            // Show 3 total pages.
            return 3;
        }

        @Override
        public CharSequence getPageTitle(int position) {
            switch (position) {
                case 0:
                    return "GRUPY";
                case 1:
                    return "CHAT";
                case 2:
                    return "KAMERA";
            }
            return null;
        }
    }
}
