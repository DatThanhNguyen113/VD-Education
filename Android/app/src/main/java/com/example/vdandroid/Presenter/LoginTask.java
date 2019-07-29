package com.example.vdandroid.Presenter;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;

import com.example.vdandroid.API.UrlConnection;
import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.Model.LoginModel;
import com.example.vdandroid.SQLite.SQLite;
import com.example.vdandroid.View.Interface.IViewLogin;
import com.example.vdandroid.View.LoginActivity;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import static java.security.AccessController.getContext;

public class LoginTask extends AsyncTask<Void, Boolean, Integer> {
    private IViewLogin iViewLogin;
    private Context mContext;
    private Map<String, String> mMap;
    private ProgressDialog dialog;
    private SQLite sqLite;
    private List<LoginModel> loginModelList;
    private SharedPreferences sharedPreferences;

    private int status_code = 0;
    private String id = "";
    private int role_id = 0;
    private String role_code = "";
    private String role_name = "";
    private String sign_in_session = "";


    public LoginTask(Context context, IViewLogin iViewLogin, Map<String, String> map) {
        this.mContext = context;
        this.iViewLogin = iViewLogin;
        this.mMap = map;
    }

    @Override
    protected void onPreExecute() {
        sqLite = new SQLite( mContext );
        loginModelList = sqLite.selectLogin();
        if(loginModelList.size()>0){
            sqLite.deleteLogin();
        }
        dialog = ProgressDialog.show( mContext, "", "Sign-in.Please wait...." );
        dialog.show();
    }

    @Override
    protected Integer doInBackground(Void... voids) {
        UrlConnection connection = new UrlConnection( mContext );
        BufferedReader reader = null;
        HttpURLConnection httpURLConnection = connection.ConnectContent( "/accountservice/signin" );
        try {
            JSONObject jsonObject = new JSONObject();
            Iterator iterator = mMap.keySet().iterator();
            while (iterator.hasNext()) {
                String key = (String) iterator.next();
                String value = mMap.get( key );
                jsonObject.put( key, value );
            }
            OutputStream os = httpURLConnection.getOutputStream();
            BufferedWriter writer = new BufferedWriter( new OutputStreamWriter( os, "UTF-8" ) );
            writer.write( String.valueOf( jsonObject ) );
            writer.flush();
            writer.close();
            os.close();

            httpURLConnection.connect();
            JSONObject responseObject = connection.ResponseObject( httpURLConnection );
            if (responseObject != null) {
                JSONArray jsonArray = responseObject.getJSONArray( "response_data" );
                status_code = responseObject.getInt( "status_code" );
                if (jsonArray != null) {
                    JSONObject childObject = jsonArray.getJSONObject( 0 );
                    id = childObject.getString( "id" );
                    role_id = childObject.getInt( "role_id" );
                    role_code = childObject.getString( "role_code" );
                    role_name = childObject.getString( "role_name" );
                    sign_in_session = childObject.getString( "sign_in_session" );
                    ((UserInfoBuffer) mContext.getApplicationContext()).setID( id );
                    ((UserInfoBuffer) mContext.getApplicationContext()).setRole_ID( role_id );
                    ((UserInfoBuffer) mContext.getApplicationContext()).setSession( sign_in_session );
                    ((UserInfoBuffer) mContext.getApplicationContext()).setRole_Code( role_code );
                    ((UserInfoBuffer) mContext.getApplicationContext()).setRole_Name( role_name );

                }
            }
            publishProgress(true);


        } catch (Exception ex) {
            ex.printStackTrace();
        }

        return status_code;
    }

    @Override
    protected void onProgressUpdate(Boolean... values) {
        if (values[0] == true){
            dialog.dismiss();
        }
    }

    @Override
    protected void onPostExecute(Integer integer) {
        try {
            loginModelList = sqLite.selectLogin();
            if (status_code == 200) {
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                sharedPreferences = mContext.getSharedPreferences( "RememberLogin", mContext.MODE_PRIVATE );
                SharedPreferences.Editor editor = sharedPreferences.edit();
                editor.putString( "id", id );
                editor.putInt( "role_id", role_id );
                editor.putString( "sign_in_session", sign_in_session );
                editor.putString( "role_code", role_code );
                editor.putString( "role_name", role_name );
                editor.commit();
                if (loginModelList.size() == 0) {
                    sqLite.insertLogin( id, role_id, role_code, role_name, sign_in_session );
                } else {
                    for (int i = 0; i < loginModelList.size(); i++) {
                        if (!loginModelList.get( i ).getID().equals( id )) {
                            sqLite.insertLogin( id, role_id, role_code, role_name, sign_in_session );
                        }
                    }
                }
                iViewLogin.onLoginSuccess();

            }else{
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                iViewLogin.onLoginFail();
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
