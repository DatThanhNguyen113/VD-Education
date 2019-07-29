package com.example.vdandroid.Presenter;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;

import com.example.vdandroid.API.UrlConnection;
import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.FragmentNotification;
import com.example.vdandroid.Model.NotificationModel;
import com.example.vdandroid.SQLite.SQLite;
import com.example.vdandroid.View.Interface.IViewNotification;
import com.google.gson.Gson;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.util.ArrayList;

public class NotificationTask extends AsyncTask<Void, Boolean, Integer> {
    private Context mContext;
    private IViewNotification iViewNotification;
    private ProgressDialog dialog;
    private int status_code = 0;
    private SQLite sqLite;
    private String role_name = "";

    public NotificationTask(Context context, IViewNotification iViewNotification) {
        this.mContext = context;
        this.iViewNotification = iViewNotification;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
        sqLite = new SQLite( mContext );
        dialog = ProgressDialog.show( mContext, "", "Loading Notification.Please wait...." );
        dialog.show();
    }

    @Override
    protected Integer doInBackground(Void... voids) {
        UrlConnection connection = new UrlConnection( mContext );
        BufferedReader reader = null;
        HttpURLConnection httpURLConnection = connection.ConnectContent( "/subject/getNotice" );
        try {
            JSONObject jsonObject = new JSONObject();
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
                FragmentNotification.notificationList = new ArrayList<>();
                if (jsonArray != null) {
                    for (int i = 0; i < jsonArray.length(); i++ ){
                        JSONObject childObject = jsonArray.getJSONObject( i );
                        NotificationModel model = new Gson().fromJson( childObject.toString(), NotificationModel.class );
                        FragmentNotification.notificationList.add( model );
                    }
                }
            }
            publishProgress( true );
        } catch (Exception ex) {
            ex.printStackTrace();
        }

        return status_code;
    }

    @Override
    protected void onProgressUpdate(Boolean... values) {
        if (values[0]) {
            dialog.dismiss();
        }
    }

    @Override
    protected void onPostExecute(Integer integer) {
        super.onPostExecute( integer );

        try {
            if (status_code == 200) {
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                iViewNotification.onSuccess();
            } else {
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                iViewNotification.onFail();

            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
