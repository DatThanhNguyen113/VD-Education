package com.example.vdandroid.View;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.Model.StudentModel;
import com.example.vdandroid.Model.TeacherModel;
import com.example.vdandroid.Presenter.ChangePassTask;
import com.example.vdandroid.Presenter.UpdateInfoTask;
import com.example.vdandroid.Presenter.UserInfoTask;
import com.example.vdandroid.R;
import com.example.vdandroid.SQLite.SQLite;
import com.example.vdandroid.View.Interface.IViewUpdateInfo;
import com.example.vdandroid.View.Interface.IViewUserInfo;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class StudentActivity extends AppCompatActivity {
    private ImageView imgBackUserInfo;
    private EditText edtMSSV_Info, edtPassOld_Info, edtPassNew_Info, edtRetypePassNew_Info;
    private EditText edtFullName, edtBirthDay, edtEmail_Info, edtPhoneNumber_Info, edtCountry_Info, edtAddress_Info;
    private FloatingActionButton btnChange;
    private SQLite sqLite;
    private List<StudentModel> listStudent;
    private List<TeacherModel> listTeacher;
    private RadioButton radioNam, radioNu;
    private String role_name = "";
    private RadioGroup radioGroup;
    private TextView tvPhoneNumber, tvCountry, tvAddress;


    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate( savedInstanceState );
        setContentView( R.layout.user_info );
        onInit();
        sqLite = new SQLite( StudentActivity.this );
        onEvent();
        onGetUserInfo();

    }

    private void onEvent() {
        edtBirthDay.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                choosenBirthDay();
            }
        } );

        imgBackUserInfo.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        } );

        btnChange.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                listStudent = sqLite.selectStudentInfo();
                String email = edtEmail_Info.getText().toString();
                String gender_id = "";
                String country = edtCountry_Info.getText().toString();
                String birth_date = edtBirthDay.getText().toString();
                @SuppressLint("SimpleDateFormat") SimpleDateFormat simpleDateFormat = new SimpleDateFormat( "yyyy-MM-dd" );
                int nam = 0, thang = 0, ngay = 0;
                String birthday = edtBirthDay.getText().toString();
                if (!birth_date.equals( "" )) {
                    String[] items = birthday.split( "/" );
                    ngay = Integer.valueOf( items[0] );
                    thang = Integer.valueOf( items[1] ) - 1;
                    nam = Integer.valueOf( items[2] );
                }
                Calendar calendar = Calendar.getInstance();
                calendar.set( nam,thang,ngay );
                String ngaysinh = simpleDateFormat.format( calendar.getTime() );
                if(radioNam.isChecked()){
                    gender_id = "0";
                }else{
                    gender_id = "1";
                }
                String address = edtAddress_Info.getText().toString();
                String phonenumber = edtPhoneNumber_Info.getText().toString();
                int role_id = ((UserInfoBuffer) StudentActivity.this.getApplicationContext()).getRole_ID();
                Map<String, String> mMap = new HashMap<>();
                mMap.put( "role_id", String.valueOf( role_id ) );
                mMap.put( "first_name", listStudent.get( 0 ).getFirst_name() );
                mMap.put( "last_name", listStudent.get( 0 ).getLast_name() );
                mMap.put( "email", edtEmail_Info.getText().toString() );
                mMap.put( "birth_date", ngaysinh );
                mMap.put( "gender_id", gender_id );
                mMap.put( "country" , country );
                mMap.put( "address", address );
                mMap.put( "phone_number", phonenumber );
                onUpdateInfo( mMap );

                String passold = edtPassOld_Info.getText().toString();
                String passnew = edtPassNew_Info.getText().toString();
                String confirmPass = edtRetypePassNew_Info.getText().toString();
                if(passold.equals( "" ) && passnew.equals( "" ) && confirmPass.equals( "" )){

                }else{
                    if(passnew.equals( confirmPass )){
                        Map<String,String> map = new HashMap<>();
                        map.put( "password", passold);
                        map.put( "new_pass",passnew );
                        onChangePassword( map );
                    }else{
                        Toast.makeText( StudentActivity.this, "Confirm Pass Wrong", Toast.LENGTH_SHORT ).show();
                    }

                }
            }
        } );
    }

    @SuppressLint("SetTextI18n")
    private void onGetUserInfo(){
        role_name = ((UserInfoBuffer) getApplicationContext()).getRole_Name();
        if(role_name.equals( "STUDENT" )){
            listStudent = sqLite.selectStudentInfo();
            edtEmail_Info.setText( listStudent.get( 0 ).getEmail() );
            edtFullName.setText( listStudent.get( 0 ).getFirst_name() + " " + listStudent.get( 0 ).getLast_name() );
            edtPhoneNumber_Info.setText( listStudent.get( 0 ).getPhone_number() );
            String[] mbirthday1 = listStudent.get( 0 ).getBirth_date().split( "-" );
            String nam = mbirthday1[0];
            String thang = mbirthday1[1];
            String mbirthday2 = mbirthday1[2].substring( 0,2 );
            String ngay = mbirthday2;
            edtBirthDay.setText( ngay + "/" + thang + "/" + nam );
            edtCountry_Info.setText( listStudent.get( 0 ).getCountry() );
            //gender_ID : 1 = Nu, 0 = Nam;
            int genderID = listStudent.get( 0 ).getGender_id();
            if(genderID == 0){
                radioNam.setChecked( true );
            }else{
                radioNu.setChecked( true );
            }
            edtAddress_Info.setText( listStudent.get( 0 ).getAddress() );
            String id = ((UserInfoBuffer) getApplicationContext()).getID();
            edtMSSV_Info.setText( id );

        }else{
            listTeacher = sqLite.selectTeacherInfo();
            edtEmail_Info.setText( listTeacher.get( 0 ).getEmail() );
            edtFullName.setText( listTeacher.get( 0 ).getName() );
            String[] mbirthday1 = listTeacher.get( 0 ).getBirth_date().split( "-" );
            String nam = mbirthday1[0];
            String thang = mbirthday1[1];
            String mbirthday2 = mbirthday1[2].substring( 0,2 );
            String ngay = mbirthday2;
            edtBirthDay.setText( ngay + "/" + thang + "/" + nam );
            edtAddress_Info.setVisibility( View.GONE );
            edtCountry_Info.setVisibility( View.GONE );
            edtPhoneNumber_Info.setVisibility( View.GONE );
            edtMSSV_Info.setText( listTeacher.get( 0 ).getEmail() );
            tvPhoneNumber.setVisibility( View.GONE );
            tvAddress.setVisibility( View.GONE );
            tvCountry.setVisibility( View.GONE );
            radioGroup.setVisibility( View.GONE );
        }

    }

    private void choosenBirthDay() {
        int nam = 0, thang = 0, ngay = 0;
        String birthday = edtBirthDay.getText().toString();
        if (!birthday.equals( "" )) {
            String[] items = birthday.split( "/" );
            ngay = Integer.valueOf( items[0] );
            thang = Integer.valueOf( items[1] ) - 1;
            nam = Integer.valueOf( items[2] );
        }
        DatePickerDialog datePickerDialog = new DatePickerDialog( this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker datePicker, int year, int month, int day) {
                Calendar calendar = Calendar.getInstance();
                calendar.set( year,month,day );
                @SuppressLint("SimpleDateFormat") SimpleDateFormat simpleDateFormat = new SimpleDateFormat( "dd/MM/yyyy" );
                edtBirthDay.setText( simpleDateFormat.format( calendar.getTime() ) );
            }
        }, nam, thang, ngay );

        datePickerDialog.show();
    }

    private void onChangePassword(Map<String, String> mMap){
        new ChangePassTask( StudentActivity.this, new IViewUpdateInfo() {
            @Override
            public void onGetSuccess() {
                Toast.makeText( StudentActivity.this, "Change Pass Success", Toast.LENGTH_SHORT ).show();
                ((UserInfoBuffer) getApplicationContext()).setID( "" );
                ((UserInfoBuffer) getApplicationContext()).setRole_ID( 0 );
                ((UserInfoBuffer) getApplicationContext()).setSession( "" );
                ((UserInfoBuffer) getApplicationContext()).setRole_Code( "" );
                ((UserInfoBuffer) getApplicationContext()).setRole_Name( "" );

                SharedPreferences sharedPreferences = getApplication().getSharedPreferences( "RememberLogin", getApplication().MODE_PRIVATE );
                sharedPreferences.edit().clear().commit();
                Intent intent = new Intent( StudentActivity.this, LoginActivity.class );
                intent.addFlags( Intent.FLAG_ACTIVITY_NO_ANIMATION );
                startActivity( intent );
                finish();
            }

            @Override
            public void onGetFail() {
                Toast.makeText( StudentActivity.this, "Change Pass Failed", Toast.LENGTH_SHORT ).show();
            }
        }, mMap ).execute();
    }

    private void onUpdateInfo(Map<String, String> mMap){

        new UpdateInfoTask( StudentActivity.this, new IViewUpdateInfo() {
            @Override
            public void onGetSuccess() {
                //Toast.makeText( StudentActivity.this, "Success", Toast.LENGTH_SHORT ).show();
                onReloadUserInfo();
            }

            @Override
            public void onGetFail() {
                Toast.makeText( StudentActivity.this, "Update User Info Failed",Toast.LENGTH_SHORT ).show();
            }
        }, mMap ).execute();
    }

    private void onReloadUserInfo(){
        new UserInfoTask( StudentActivity.this, new IViewUserInfo() {
            @Override
            public void onGetSuccess() {
                onGetUserInfo();
            }

            @Override
            public void onGetFail() {
                Toast.makeText( StudentActivity.this, "Error when get information user. Please try again", Toast.LENGTH_SHORT ).show();
            }
        }).execute();
    }

    private void onInit() {
        imgBackUserInfo = findViewById( R.id.imgBackUserInfo );
        edtMSSV_Info = findViewById( R.id.edtMSSV_Info );
        edtPassOld_Info = findViewById( R.id.edtPassOld_Info );
        edtPassNew_Info = findViewById( R.id.edtPassNew_Info );
        edtRetypePassNew_Info = findViewById( R.id.edtRetypePassNew_Info );
        edtFullName = findViewById( R.id.edtFullName );
        edtBirthDay = findViewById( R.id.edtBirthDay );
        edtEmail_Info = findViewById( R.id.edtEmail_Info );
        edtPhoneNumber_Info = findViewById( R.id.edtPhoneNumber_Info );
        edtCountry_Info = findViewById( R.id.edtCountry_Info );
        btnChange = findViewById( R.id.btnChange );
        radioNam = findViewById( R.id.radioNam );
        radioNu = findViewById( R.id.radioNu );
        edtAddress_Info = findViewById( R.id.edtAddress_Info );
        radioGroup = findViewById( R.id.radioGroup );
        tvPhoneNumber = findViewById( R.id.tvPhoneNumber );
        tvAddress = findViewById( R.id.tvAddress );
        tvCountry = findViewById( R.id.tvCountry );
    }

}
