package com.example.vdandroid.Presenter;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;

import com.example.vdandroid.API.UrlConnection;
import com.example.vdandroid.View.Interface.IViewUpdateMuster;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.util.Iterator;
import java.util.Map;

public class UpdateMusterTask extends AsyncTask<Void, Boolean, Integer> {
    private IViewUpdateMuster iViewUpdateMuster;
    private Context mContext;
    private Map<String, String> mMap;
    private ProgressDialog dialog;
    int status_code = 0;


    public UpdateMusterTask(Context context, IViewUpdateMuster iViewUpdateMuster, Map<String, String> map) {
        this.mContext = context;
        this.iViewUpdateMuster = iViewUpdateMuster;
        this.mMap = map;
    }

    @Override
    protected void onPreExecute() {
        dialog = ProgressDialog.show( mContext, "", "Sign-in.Please wait...." );
        dialog.show();
    }

    @Override
    protected Integer doInBackground(Void... voids) {
        UrlConnection connection = new UrlConnection( mContext );
        BufferedReader reader = null;
        HttpURLConnection httpURLConnection = connection.ConnectContent( "/subject/updateMusterStudent" );
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
            if (status_code == 200) {
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                iViewUpdateMuster.onSuccess();

            }else{
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                iViewUpdateMuster.onFail();
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}