package com.example.vdandroid.View.RegisterSubject;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ImageView;

import com.example.vdandroid.Adapter.PageAdapter;
import com.example.vdandroid.R;

public class RegisterSubjectActivity extends AppCompatActivity {
    private ViewPager mViewPager;
    private PageAdapter mPageAdapter;
    private ImageView imgBackDKMH;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate( savedInstanceState );
        setContentView( R.layout.register_subject_screen );
        onInit();
        onEvent();
        onSetupTabhost(  );
    }

    private void onInit(){
        imgBackDKMH = findViewById( R.id.imgBackDKMH );
    }

    private void onEvent(){
        imgBackDKMH.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        } );
    }

    private void onSetupTabhost() {
        TabLayout tabLayout = findViewById( R.id.tabs );
        tabLayout.setupWithViewPager( mViewPager );
        tabLayout.addTab( tabLayout.newTab().setText( "Đăng kí" ) );
        tabLayout.addTab( tabLayout.newTab().setText( "Đã đăng kí" ) );
        tabLayout.setTabGravity( TabLayout.GRAVITY_FILL );
        mPageAdapter = new PageAdapter( getSupportFragmentManager(), tabLayout.getTabCount() );
        mViewPager = findViewById( R.id.viewTrade );
        mViewPager.setAdapter( mPageAdapter );
        mViewPager.addOnPageChangeListener( new TabLayout.TabLayoutOnPageChangeListener( tabLayout ) );
        tabLayout.setOnTabSelectedListener( new TabLayout.OnTabSelectedListener() {
            @Override
            public void onTabSelected(TabLayout.Tab tab) {
                if (mViewPager != null) {
                    mViewPager.setCurrentItem(tab.getPosition());
                }
            }

            @Override
            public void onTabUnselected(TabLayout.Tab tab) {

            }

            @Override
            public void onTabReselected(TabLayout.Tab tab) {

            }
        } );
    }
}
