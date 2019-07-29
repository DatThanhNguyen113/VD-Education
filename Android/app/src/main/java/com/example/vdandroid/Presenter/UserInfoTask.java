package com.example.vdandroid.Presenter;

import android.annotation.SuppressLint;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;

import com.example.vdandroid.API.UrlConnection;
import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.Model.StudentModel;
import com.example.vdandroid.Model.TeacherModel;
import com.example.vdandroid.SQLite.SQLite;
import com.example.vdandroid.View.Interface.IViewUserInfo;
import com.google.gson.Gson;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.util.List;

public class UserInfoTask extends AsyncTask<Void, Boolean, Integer> {
    @SuppressLint("StaticFieldLeak")
    private Context mContext;
    private IViewUserInfo iViewUserInfo;
    private ProgressDialog dialog;
    private int status_code = 0;
    private SQLite sqLite;
    private String role_name = "";

    public UserInfoTask(Context context, IViewUserInfo iViewUserInfo) {
        this.mContext = context;
        this.iViewUserInfo = iViewUserInfo;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
        sqLite = new SQLite( mContext );
        role_name = ((UserInfoBuffer) mContext.getApplicationContext()).getRole_Name();
        if(role_name.equals( "STUDENT" )){
            List<StudentModel> studentModelList = sqLite.selectStudentInfo();
            if (studentModelList.size() > 0) {
                sqLite.deleteStudent();
            }
        }else{
            List<TeacherModel> teacherModelList = sqLite.selectTeacherInfo();
            if (teacherModelList.size() > 0) {
                sqLite.deleteTeacher();
            }
        }


        dialog = ProgressDialog.show( mContext, "", "Loading User Information.Please wait...." );
        dialog.show();
    }

    @Override
    protected Integer doInBackground(Void... voids) {
        UrlConnection connection = new UrlConnection( mContext );
        BufferedReader reader = null;
        HttpURLConnection httpURLConnection = connection.ConnectContent( "/accountservice/userinfo" );
        int role_id = ((UserInfoBuffer) mContext.getApplicationContext()).getRole_ID();
        try {
            JSONObject jsonObject = new JSONObject();
            jsonObject.put( "role_id", role_id );
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
                    if(role_name.equals( "STUDENT" )){
                        StudentModel model = new StudentModel();
                        model = new Gson().fromJson( childObject.toString(), StudentModel.class );
                        sqLite.insertStudentInfo( model );
                    }else{
                        TeacherModel model = new TeacherModel();
                        model = new Gson().fromJson( childObject.toString(), TeacherModel.class );
                        sqLite.insertTeacherInfo( model );
                    }
//                    model.setID( childObject.getInt( "id" ) );
//                    model.setFirstName( childObject.getString( "first_name" ) );
//                    model.setLastName( childObject.getString( "last_name" ) );
//                    model.setEmail( childObject.getString( "email" ) );
//                    model.setBirthDate( childObject.getString( "birth_date" ) );
//                    model.setGenderID( childObject.getInt( "gender_id" ) );
//                    model.setGenderName( childObject.getString( "gender_name" ) );
//                    model.setCountry( childObject.getString( "country" ) );
//                    model.setAddress( childObject.getString( "address" ) );
//                    model.setPhoneNumber( childObject.getString( "phone_number" ) );
//                    model.setTrainingSystemID( childObject.getInt( "training_system_id" ) );
//                    model.setTrainingSystemName( childObject.getString( "training_system_name" ) );
//                    model.setRole( childObject.getString( "role" ) );
//                    model.setClassCode( childObject.getString( "class_code" ) );
//                    model.setClassID( childObject.getInt( "class_id" ) );
//                    model.setClassName( childObject.getString( "class_name" ) );
//                    model.setSchoolYearName( childObject.getString( "school_year_name" ) );
//                    model.setStartYear( childObject.getInt( "start_year" ) );
//                    model.setEndYear( childObject.getInt( "end_year" ) );
//                    model.setSchoolYearID( childObject.getInt( "school_year_id" ) );

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
                iViewUserInfo.onGetSuccess();
            } else {
                if(dialog.isShowing()){
                    dialog.dismiss();
                }
                iViewUserInfo.onGetFail();

            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
