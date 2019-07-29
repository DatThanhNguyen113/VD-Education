package com.example.vdandroid.Adapter;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

import com.example.vdandroid.View.RegisterSubject.TabRegistedSubject;
import com.example.vdandroid.View.RegisterSubject.TabRegisterSubject;

public class PageAdapter extends FragmentStatePagerAdapter {
    private int mNumOfTabs;

    public PageAdapter(FragmentManager fm, int NumOfTabs) {
        super( fm );
        this.mNumOfTabs = NumOfTabs;
    }

    @Override
    public Fragment getItem(int position) {
        switch (position) {
            case 0:
                TabRegisterSubject tabRegisterSubject = new TabRegisterSubject();
                return tabRegisterSubject;
            case 1:
                TabRegistedSubject tabRegistedSubject = new TabRegistedSubject();
                return tabRegistedSubject;
            default:
                return new TabRegisterSubject();
        }
    }

    @Override
    public int getCount() {
        return mNumOfTabs;
    }
}
