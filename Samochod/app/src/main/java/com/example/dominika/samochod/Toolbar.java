package com.example.dominika.samochod;
import android.support.design.widget.TabLayout;
import android.support.v7.app.AppCompatActivity;
import android.support.v4.view.ViewPager;
import android.os.Bundle;

//KLASA SO WYSWIETLENIA I OBSLUGI TOOLBAR
public class Toolbar extends AppCompatActivity {

    private ViewPager mViewPager;
    private TabLayout tabLayout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

            setContentView(R.layout.toolbar);

            mViewPager = (ViewPager) findViewById(R.id.container);

            //USTAWIENIE LICZYBY KART KTORE MA GENEROWAC
            mViewPager.setOffscreenPageLimit(4);

            PagerAdapter adapter = new PagerAdapter(getSupportFragmentManager());

            //DODANIE FRAGMENTOW, ODPOWIEDNICH KLAS DO ODPOWIEDNICH KART
            adapter.addFragment(new Groups(), "Grupa");
            adapter.addFragment(new Chat(), "Czat");
            adapter.addFragment(new Camera(), "Zdjęcie");
            adapter.addFragment(new Statistics(), "Statystyki");
            mViewPager.setAdapter(adapter);

            tabLayout = (TabLayout) findViewById(R.id.tabs);
            tabLayout.setupWithViewPager(mViewPager);

            setTabLayout();

    }

    //USTAWIENIE IKON ZNAJDUJACYCH SIE W ZAKLADKACH
    private void setTabLayout(){
        tabLayout.getTabAt(0).setIcon(R.drawable.group_icon);
        tabLayout.getTabAt(1).setIcon(R.drawable.chat_icon);
        tabLayout.getTabAt(2).setIcon(R.drawable.camera_icon);
        tabLayout.getTabAt(3).setIcon(R.drawable.statistics);
    }
}
