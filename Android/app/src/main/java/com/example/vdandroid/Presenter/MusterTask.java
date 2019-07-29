package com.example.vdandroid.Presenter;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;

import com.example.vdandroid.API.UrlConnection;
import com.example.vdandroid.Model.MusterModel;
import com.example.vdandroid.View.Interface.IViewMuster;
import com.example.vdandroid.View.Teacher.MusterActivity;
import com.google.gson.Gson;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.util.ArrayList;

public class MusterTask extends AsyncTask<Void, Boolean, Integer> {
    private Context mContext;
    private IViewMuster iViewMuster;
    private ProgressDialog dialog;
    private int status_code = 0;
    private String role_name = "";

    public MusterTask(Context context, IViewMuster iViewMuster) {
        this.mContext = context;
        this.iViewMuster = iViewMuster;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
        dialog = ProgressDialog.show( mContext, "", "Loading List Muster.Please wait...." );
        dialog.show();
    }

    @Override
    protected Integer doInBackground(Void... voids) {
        UrlConnection connection = new UrlConnection( mContext );
        BufferedReader reader = null;
        HttpURLConnection httpURLConnection = connection.ConnectContent( "/subject/getMuster" );
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
                MusterActivity.list = new ArrayList<>();
                if (jsonArray != null) {
                    for (int i = 0; i < jsonArray.length(); i++ ){
                        JSONObject childObject = jsonArray.getJSONObject( i );
                        MusterModel model = new Gson().fromJson( childObject.toString(), MusterModel.class );
                        MusterActivity.list.add( model );
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
                iViewMuster.onSuccess();
            } else {
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                iViewMuster.onFail();

            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
