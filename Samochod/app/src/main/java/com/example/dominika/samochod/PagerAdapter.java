package com.example.dominika.samochod;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Dominika on 14.04.2017.
 */

//KLASA DO OBSLUGI WIELU KART (PONIEWAZ KORZYSTAMY Z VIEW PAGER)
public class PagerAdapter extends FragmentPagerAdapter {

    private final List<Fragment> FragmentList = new ArrayList<>();

    private final List<String> FragmentTitleNames = new ArrayList();

    public PagerAdapter(FragmentManager fm) {
        super(fm);
    }

    public void addFragment(Fragment fragment, String title) {
        FragmentList.add(fragment);
        FragmentTitleNames.add(title);
    }

    @Override
    public Fragment getItem(int position) {
        return FragmentList.get(position);
    }

    @Override
    public int getCount() {
        return FragmentList.size();
    }

    @Override
    public CharSequence getPageTitle(int position)
    {
        return FragmentTitleNames.get(position);
    }
}

