package com.example.vdandroid.View;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.design.widget.NavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.FragmentHome;
import com.example.vdandroid.FragmentLesson;
import com.example.vdandroid.FragmentNotification;
import com.example.vdandroid.Model.LoginModel;
import com.example.vdandroid.Model.StudentModel;
import com.example.vdandroid.Model.TeacherModel;
import com.example.vdandroid.Presenter.NotificationTask;
import com.example.vdandroid.Presenter.UserInfoTask;
import com.example.vdandroid.R;
import com.example.vdandroid.SQLite.SQLite;
import com.example.vdandroid.Service.NotificationService;
import com.example.vdandroid.View.Interface.IViewNotification;
import com.example.vdandroid.View.Interface.IViewUserInfo;

import java.util.List;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    public static final String FRAGMENT_HOME = "FRAGMENT_HOME";
    public static final String FRAGMENT_LESSON = "FRAGMENT_LESSON";
    public static final String FRAGMENT_NOTIFICATION = "FRAGMENT_NOTIFICATION";
    NavigationView navigationView;
    TextView tvFullName;
    TextView tvClassCode;
    TextView tvMSSV;
    LinearLayout linear_ClassCode;
    String mMSSV = "";
    List<StudentModel> listStudent;
    List<TeacherModel> listTeacher;
    String role_name = "";

    List<LoginModel> listLogin;
    SQLite sqLite;

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {
        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {
            switch (menuItem.getItemId()) {
                case R.id.action_home:
                    if (listLogin.get( 0 ).getRole_ID() == 1) {
                        replaceFragment( com.example.vdandroid.View.Teacher.FragmentHome.newInstance(), FRAGMENT_HOME );
                    } else {
                        replaceFragment( FragmentHome.newInstance(), FRAGMENT_HOME );
                    }
                    return true;
                case R.id.action_lesson:
                    replaceFragment( FragmentLesson.newInstance(), FRAGMENT_LESSON );
                    return true;
                case R.id.action_notification:
                    replaceFragment( FragmentNotification.newInstance(), FRAGMENT_NOTIFICATION );
                    return true;
            }

            return false;
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate( savedInstanceState );
        setContentView( R.layout.activity_main );
        Toolbar toolbar = (Toolbar) findViewById( R.id.toolbar );
        setSupportActionBar( toolbar );
        sqLite = new SQLite( MainActivity.this );

        DrawerLayout drawer = (DrawerLayout) findViewById( R.id.drawer_layout );
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close );
        drawer.addDrawerListener( toggle );
        toggle.syncState();

        navigationView = (NavigationView) findViewById( R.id.nav_view );
        navigationView.setNavigationItemSelectedListener( this );

        BottomNavigationView navigation = (BottomNavigationView) findViewById( R.id.bottom_navigation );
        navigation.setOnNavigationItemSelectedListener( mOnNavigationItemSelectedListener );

        listLogin = sqLite.selectLogin();
        if (listLogin.get( 0 ).getRole_Name().equals( "TEACHER" )) {
            FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
            ft.add( R.id.fragment_container, com.example.vdandroid.View.Teacher.FragmentHome.newInstance(), FRAGMENT_HOME )
                    .commit();
        } else {
            FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
            ft.add( R.id.fragment_container, FragmentHome.newInstance(), FRAGMENT_HOME )
                    .commit();
        }
        onInit();
        onIntent();
        onGetUserInfo();
        onGetNotice();
        startService( new Intent( MainActivity.this, NotificationService.class ) );
    }

    private void onGetViewNavHeader() {
        role_name = ((UserInfoBuffer) getApplicationContext()).getRole_Name();
        View nav_header = navigationView.getHeaderView( 0 );
        TextView tvHeaderFullName = nav_header.findViewById( R.id.tvHeaderFullName );
        TextView tvHeaderMSSV = nav_header.findViewById( R.id.tvHeaderMSSV );
        TextView tvHeaderEmail = nav_header.findViewById( R.id.tvHeaderEmail );
        if (role_name.equals( "STUDENT" )) {
            listStudent = sqLite.selectStudentInfo();
            tvHeaderFullName.setText( listStudent.get( 0 ).getFirst_name() + " " + listStudent.get( 0 ).getLast_name() );
            tvHeaderEmail.setText( listStudent.get( 0 ).getEmail() );
            tvHeaderMSSV.setText( mMSSV );
        } else {
            listTeacher = sqLite.selectTeacherInfo();
            tvHeaderFullName.setText( listTeacher.get( 0 ).getName() );
            tvHeaderEmail.setText( listTeacher.get( 0 ).getEmail() );
            tvHeaderMSSV.setText( listTeacher.get( 0 ).getId() );
        }

    }

    private void onIntent() {
        Intent intent = getIntent();
        mMSSV = intent.getStringExtra( "MSSV" );
    }


    private void onGetUserInfo() {
        final String MSSV = ((UserInfoBuffer) getApplicationContext()).getID();
        role_name = ((UserInfoBuffer) getApplicationContext()).getRole_Name();
        new UserInfoTask( MainActivity.this, new IViewUserInfo() {
            @Override
            public void onGetSuccess() {
                if (role_name.equals( "STUDENT" )) {
                    listStudent = sqLite.selectStudentInfo();
                    tvFullName.setText( listStudent.get( 0 ).getFirst_name() + " " + listStudent.get( 0 ).getLast_name() );
                    tvClassCode.setText( listStudent.get( 0 ).getClass_code() );

                } else {
                    listTeacher = sqLite.selectTeacherInfo();
                    tvFullName.setText( listTeacher.get( 0 ).getName() );
                    tvMSSV.setText( listTeacher.get( 0 ).getId() );
                    linear_ClassCode.setVisibility( View.GONE );
                    //tvClassCode.setText( listStudent.get( 0 ).getClass_code() );
                }
                listLogin = sqLite.selectLogin();
                tvMSSV.setText( MSSV );
                onGetViewNavHeader();
            }

            @Override
            public void onGetFail() {
                Toast.makeText( MainActivity.this, "Error when get information user. Please try again", Toast.LENGTH_SHORT ).show();
            }
        } ).execute();
    }

    private void onGetNotice(){
        new NotificationTask( MainActivity.this, new IViewNotification() {
            @Override
            public void onSuccess() {

            }

            @Override
            public void onFail() {
                Toast.makeText( MainActivity.this, "Error when get information user. Please try again", Toast.LENGTH_SHORT ).show();
            }
        } ).execute();
    }

    private void onInit() {
        tvFullName = findViewById( R.id.tvFullName );
        tvClassCode = findViewById( R.id.tvClassCode );
        tvMSSV = findViewById( R.id.tvMSSV );
        linear_ClassCode = findViewById( R.id.linear_ClassCode );
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }


    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById( R.id.drawer_layout );
        if (drawer.isDrawerOpen( GravityCompat.START )) {
            drawer.closeDrawer( GravityCompat.START );
        } else {
            super.onBackPressed();
        }
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_logout) {
            // Handle the camera action
            ((UserInfoBuffer) getApplicationContext()).setID( "" );
            ((UserInfoBuffer) getApplicationContext()).setRole_ID( 0 );
            ((UserInfoBuffer) getApplicationContext()).setSession( "" );
            ((UserInfoBuffer) getApplicationContext()).setRole_Code( "" );
            ((UserInfoBuffer) getApplicationContext()).setRole_Name( "" );

            SharedPreferences sharedPreferences = getApplication().getSharedPreferences( "RememberLogin", getApplication().MODE_PRIVATE );
            sharedPreferences.edit().clear().commit();
            Intent intent = new Intent( MainActivity.this, LoginActivity.class );
            intent.addFlags( Intent.FLAG_ACTIVITY_NO_ANIMATION );
            startActivity( intent );
            finish();
        }
//        else if (id == R.id.nav_gallery) {
//
//        } else if (id == R.id.nav_slideshow) {
//
//        } else if (id == R.id.nav_manage) {
//
//        } else if (id == R.id.nav_share) {
//
//        } else if (id == R.id.nav_send) {
//
//        }

        DrawerLayout drawer = (DrawerLayout) findViewById( R.id.drawer_layout );
        drawer.closeDrawer( GravityCompat.START );
        return true;
    }


    private void replaceFragment(Fragment newFragment, String tag) {
        FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
        ft.replace( R.id.fragment_container, newFragment, tag )
                .commit();

    }
}
