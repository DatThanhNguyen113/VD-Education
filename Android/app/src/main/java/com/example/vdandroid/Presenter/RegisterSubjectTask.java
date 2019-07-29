package com.example.vdandroid.Presenter;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;

import com.example.vdandroid.API.UrlConnection;
import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.Model.RegisterSubjectModel;
import com.example.vdandroid.View.Interface.IViewRegisterSubject;
import com.example.vdandroid.View.RegisterSubject.TabRegisterSubject;
import com.google.gson.Gson;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.util.ArrayList;
import java.util.List;

public class RegisterSubjectTask extends AsyncTask<Void, Boolean, Integer> {
    private Context mContext;
    private IViewRegisterSubject iView;
    private int status_code = 0;
    //    private SQLite sqLite;
    private ProgressDialog dialog;

    public RegisterSubjectTask(Context mContext, IViewRegisterSubject iView) {
        this.mContext = mContext;
        this.iView = iView;
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
        HttpURLConnection httpURLConnection = connection.ConnectContent( "/subject/getsubjectregister" );
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
                if (jsonArray != null) {
                    List<RegisterSubjectModel> subjectModelList = new ArrayList<>();
                    for(int i = 0; i < jsonArray.length(); i++){
                        JSONObject childObject = jsonArray.getJSONObject(i);
                        RegisterSubjectModel model = new Gson().fromJson( childObject.toString(), RegisterSubjectModel.class );
                        subjectModelList.add( model );
                    }
                    TabRegisterSubject.list = subjectModelList;
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
                iView.onGetSuccess();
            } else {
                iView.onGetFail();
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
