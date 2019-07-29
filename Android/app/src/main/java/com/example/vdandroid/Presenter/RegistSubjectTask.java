package com.example.vdandroid.Presenter;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;

import com.example.vdandroid.API.UrlConnection;
import com.example.vdandroid.View.Interface.IViewRegistSubject;
import com.example.vdandroid.View.Interface.IViewUpdateInfo;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.util.Iterator;
import java.util.Map;

public class RegistSubjectTask extends AsyncTask<Void, Boolean, Integer> {
    private Context mContext;
    private IViewRegistSubject iView;
    private int status_code = 0;
    private Map<String, String> mMap;
    private ProgressDialog dialog;

    public RegistSubjectTask(Context mContext, IViewRegistSubject iView, Map<String, String> map) {
        this.mContext = mContext;
        this.iView = iView;
        this.mMap = map;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
        dialog = ProgressDialog.show( mContext, "", "Loading please wait...." );
        dialog.show();
    }


    @Override
    protected Integer doInBackground(Void... voids) {
        UrlConnection connection = new UrlConnection( mContext );
        BufferedReader reader = null;
        HttpURLConnection httpURLConnection = connection.ConnectContent( "/subject/registsubject" );
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
                status_code = responseObject.getInt( "status_code" );
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
                iView.onGetSuccess();
            } else {
                iView.onGetFail();
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}

