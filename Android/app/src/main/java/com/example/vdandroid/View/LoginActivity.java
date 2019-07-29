package com.example.vdandroid.View;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.Handler;
import android.os.HandlerThread;
import android.os.Looper;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.Model.LoginModel;
import com.example.vdandroid.Presenter.LoginTask;
import com.example.vdandroid.R;
import com.example.vdandroid.SQLite.SQLite;
import com.example.vdandroid.View.Interface.IViewLogin;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class LoginActivity extends AppCompatActivity {
    private EditText edtMSSV, edtPass;
    private Button btnLogin;
    private String mMSSV = "";
    private String mPass = "";
    private SQLite sqLite;
    List<LoginModel> loginModelList;


    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate( savedInstanceState );
        setContentView( R.layout.login_screen );
        onInit();
        sqLite = new SQLite( LoginActivity.this );
        loginModelList = sqLite.selectLogin();
        onEvent();
        if(loginModelList.size() > 0){
            checkLoginRemember();
        }


    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }

    private void onEvent() {
        btnLogin.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mMSSV = edtMSSV.getText().toString();
                mPass = edtPass.getText().toString();
                if (mMSSV.equals( "" ) || mPass.equals( "" )) {
                    Toast.makeText( LoginActivity.this, "Vui lòng nhập thông tin để đăng nhập", Toast.LENGTH_LONG ).show();
                } else {
                    Map<String, String> mMap = new HashMap<>();
                    mMap.put( "user_name", mMSSV );
                    mMap.put( "password", mPass );
                    new LoginTask( LoginActivity.this, new IViewLogin() {
                        @Override
                        public void onLoginSuccess() {
                            Intent intent = new Intent( LoginActivity.this, MainActivity.class );
                            intent.putExtra( "MSSV", mMSSV );
                            startActivity( intent );
                            finish();
                        }

                        @Override
                        public void onLoginFail() {
                            Toast.makeText( LoginActivity.this, "Đăng nhập thất bại, vui lòng thử lại", Toast.LENGTH_SHORT ).show();
                        }
                    }, mMap ).execute();
                }

            }
        } );
    }


    private void onInit() {
        edtMSSV = findViewById( R.id.edtMSSV );
        edtPass = findViewById( R.id.edtPassword );
        btnLogin = findViewById( R.id.btnLogin );
    }

    private void checkLoginRemember(){
        SharedPreferences sharedPreferences = getSharedPreferences("RememberLogin", Context.MODE_PRIVATE);
        mMSSV = loginModelList.get( 0 ).getID();
        String id = sharedPreferences.getString( "id", "" );
        int role_id = sharedPreferences.getInt( "role_id", 0 );
        String sign_in_session = sharedPreferences.getString( "sign_in_session","" );
        String role_code = sharedPreferences.getString( "role_code","" );
        String role_name = sharedPreferences.getString( "role_name","" );
        if(sign_in_session.equals( "" )){
            Toast.makeText( LoginActivity.this, "You need to login", Toast.LENGTH_SHORT ).show();
        }else{
            ((UserInfoBuffer) getApplicationContext()).setID( id );
            ((UserInfoBuffer) getApplicationContext()).setRole_ID( role_id );
            ((UserInfoBuffer) getApplicationContext()).setSession( sign_in_session );
            ((UserInfoBuffer) getApplicationContext()).setRole_Code( role_code );
            ((UserInfoBuffer) getApplicationContext()).setRole_Name( role_name );

            Intent intent = new Intent( LoginActivity.this, MainActivity.class );
            intent.putExtra( "MSSV", mMSSV );
            startActivity( intent );
            finish();
        }
    }
}
