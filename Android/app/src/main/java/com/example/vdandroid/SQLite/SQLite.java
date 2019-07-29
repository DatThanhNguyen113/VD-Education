package com.example.vdandroid.SQLite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import com.example.vdandroid.Model.LoginModel;
import com.example.vdandroid.Model.StudentModel;
import com.example.vdandroid.Model.TeacherModel;

import java.util.ArrayList;
import java.util.List;

public class SQLite extends SQLiteOpenHelper {
    private SQLiteDatabase myDB;
    private static final String DB_NAME = "CDVD.db";
    private static final int VERSION = 2;
    private Context mContext;

    /*
     Table name
    */
    private static final String TABLE_LOGIN = "Login";
    private static final String TABLE_STUDENTINFO = "StudentInfo";
    private static final String TABLE_TEACHERINFO = "TeacherInfo";

    public SQLite(Context context) {
        super( context, DB_NAME, null, VERSION );
        mContext = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sQueryLogin = "Create table if not exists " + TABLE_LOGIN
                + "( "
                + " ID TEXT,"
                + " Role_ID INTEGER,"
                + " Role_Code TEXT,"
                + " Role_Name TEXT,"
                + " Sign_In_Session TEXT"
                + " )";

        String sQueryStudent = "Create table if not exists " + TABLE_STUDENTINFO
                + "( "
                + " ID INTEGER,"
                + " FirstName TEXT,"
                + " LastName TEXT,"
                + " Email TEXT,"
                + " BirthDate TEXT,"
                + " GenderID INTEGER,"
                + " GenderName TEXT,"
                + " Country TEXT,"
                + " Address TEXT,"
                + " PhoneNumber TEXT,"
                + " TrainingSystemID INTEGER,"
                + " TrainingSystemName TEXT,"
                + " Role TEXT,"
                + " ClassCode TEXT,"
                + " ClassID INTEGER,"
                + " ClassName TEXT,"
                + " SchoolYearName TEXT,"
                + " StartYear INTEGER,"
                + " EndYear INTEGER,"
                + " SchoolYearID INTEGER"
                + " )";

        String sQueryTeacher = "Create table if not exists " + TABLE_TEACHERINFO
                + "( "
                + " ID TEXT,"
                + " Name TEXT,"
                + " Role INTEGER,"
                + " Email TEXT,"
                + " BirthDate TEXT,"
                + " WorkUnit TEXT,"
                + " Graduating TEXT,"
                + " Diploma TEXT,"
                + " BankAccountNumber TEXT,"
                + " BankID INTEGER,"
                + " Description TEXT"
                + " )";





        db.execSQL( sQueryLogin );
        db.execSQL( sQueryStudent );
        db.execSQL( sQueryTeacher );
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL( "DROP TABLE IF EXISTS " + TABLE_LOGIN );
        db.execSQL( "DROP TABLE IF EXISTS " + TABLE_STUDENTINFO );
        db.execSQL( "DROP TABLE IF EXISTS " + TABLE_TEACHERINFO );


        onCreate( db );
    }

    public void OpenDB() {
        myDB = getWritableDatabase();
    }

    public void CloseDB() {
        if (myDB.isOpen() && myDB != null) {
            myDB.close();
        }
    }


    // INSERT DATA TO TABLES
    public long insertLogin(String ID, int role_id, String role_code, String role_name, String sign_in_session) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put( "ID", ID );
        values.put( "Role_ID", role_id );
        values.put( "Role_Code", role_code );
        values.put( "Role_Name", role_name );
        values.put( "Sign_In_Session", sign_in_session );
        return db.insert( TABLE_LOGIN, null, values );
    }

    public long insertStudentInfo(StudentModel studentModel) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put( "ID", studentModel.getId() );
        values.put( "FirstName", studentModel.getFirst_name() );
        values.put( "LastName", studentModel.getLast_name() );
        values.put( "Email", studentModel.getEmail() );
        values.put( "BirthDate", studentModel.getBirth_date() );
        values.put( "GenderID", studentModel.getGender_id() );
        values.put( "GenderName", studentModel.getGender_name() );
        values.put( "Country", studentModel.getCountry() );
        values.put( "Address", studentModel.getAddress() );
        values.put( "PhoneNumber", studentModel.getPhone_number() );
        values.put( "TrainingSystemID", studentModel.getTraining_system_id()  );
        values.put( "TrainingSystemName", studentModel.getTraining_system_name() );
        values.put( "Role", studentModel.getRole() );
        values.put( "ClassCode", studentModel.getClass_code() );
        values.put( "ClassID", studentModel.getClass_id() );
        values.put( "ClassName", studentModel.getClass_name() );
        values.put( "SchoolYearName", studentModel.getSchool_year_name() );
        values.put( "StartYear", studentModel.getStart_year() );
        values.put( "EndYear", studentModel.getEnd_year() );
        values.put( "SchoolYearID", studentModel.getSchool_year_id() );
        return db.insert( TABLE_STUDENTINFO, null, values );
    }

    public long insertTeacherInfo(TeacherModel teacherModel){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put( "ID", teacherModel.getId() );
        values.put( "Name", teacherModel.getName() );
        values.put( "Email", teacherModel.getEmail() );
        values.put( "BirthDate", teacherModel.getBirth_date() );
        values.put( "WorkUnit", teacherModel.getWork_unit() );
        values.put( "Graduating", teacherModel.getGraduating() );
        values.put( "Diploma", teacherModel.getDiploma() );
        values.put( "BankAccountNumber", teacherModel.getBank_account_number() );
        values.put( "BankID", teacherModel.getBank_id() );
        values.put( "Description", teacherModel.getDescription()  );
        values.put( "Role", teacherModel.getRole() );
        return db.insert( TABLE_TEACHERINFO, null, values );
    }

    // DELETE TABLES
    public void deleteLogin() {
        SQLiteDatabase db = this.getWritableDatabase();
        String sQuery = "DELETE FROM " + TABLE_LOGIN;
        db.execSQL( sQuery );
    }

    public void deleteStudent() {
        SQLiteDatabase db = this.getWritableDatabase();
        String sQuery = "DELETE FROM " + TABLE_STUDENTINFO;
        db.execSQL( sQuery );
    }

    public void deleteTeacher() {
        SQLiteDatabase db = this.getWritableDatabase();
        String sQuery = "DELETE FROM " + TABLE_TEACHERINFO;
        db.execSQL( sQuery );
    }

    // SELECT DATA FROM TABLES
    public List<LoginModel> selectLogin() {
        String sQuery = "SELECT * FROM " + TABLE_LOGIN;
        List<LoginModel> slist = new ArrayList<>();
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery( sQuery, null );
        for (cursor.moveToFirst(); !cursor.isAfterLast(); cursor.moveToNext()) {
            LoginModel loginModel = new LoginModel();
            loginModel.setID( cursor.getString( cursor.getColumnIndex( "ID" ) ) );
            loginModel.setRole_ID( cursor.getInt( cursor.getColumnIndex( "Role_ID" ) ) );
            loginModel.setRole_Code( cursor.getString( cursor.getColumnIndex( "Role_Code" ) ) );
            loginModel.setRole_Name( cursor.getString( cursor.getColumnIndex( "Role_Name" ) ) );
            loginModel.setSign_In_Session( cursor.getString( cursor.getColumnIndex( "Sign_In_Session" ) ) );
            slist.add( loginModel );
        }
        cursor.close();
        return slist;
    }

    public List<StudentModel> selectStudentInfo() {
        String sQuery = "SELECT * FROM " + TABLE_STUDENTINFO;
        List<StudentModel> slist = new ArrayList<>();
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery( sQuery, null );
        for (cursor.moveToFirst(); !cursor.isAfterLast(); cursor.moveToNext()) {
            StudentModel userModel = new StudentModel();
            userModel.setId( cursor.getInt( cursor.getColumnIndex( "ID" ) ) );
            userModel.setFirst_name( cursor.getString( cursor.getColumnIndex( "FirstName" ) ) );
            userModel.setLast_name( cursor.getString( cursor.getColumnIndex( "LastName" ) ) );
            userModel.setEmail( cursor.getString( cursor.getColumnIndex( "Email" ) ) );
            userModel.setBirth_date( cursor.getString( cursor.getColumnIndex( "BirthDate" ) ) );
            userModel.setGender_id( cursor.getInt( cursor.getColumnIndex( "GenderID" ) ) );
            userModel.setGender_name( cursor.getString( cursor.getColumnIndex( "GenderName" ) ) );
            userModel.setCountry( cursor.getString( cursor.getColumnIndex( "Country" ) ) );
            userModel.setAddress( cursor.getString( cursor.getColumnIndex( "Address" ) ) );
            userModel.setPhone_number( cursor.getString( cursor.getColumnIndex( "PhoneNumber" ) ) );
            userModel.setTraining_system_id( cursor.getInt( cursor.getColumnIndex( "TrainingSystemID" ) ) );
            userModel.setTraining_system_name( cursor.getString( cursor.getColumnIndex( "TrainingSystemName" ) ) );
            userModel.setRole( cursor.getString( cursor.getColumnIndex( "Role" ) ) );
            userModel.setClass_code( cursor.getString( cursor.getColumnIndex( "ClassCode" ) ) );
            userModel.setClass_id( cursor.getInt( cursor.getColumnIndex( "ClassID" ) ) );
            userModel.setClass_name( cursor.getString( cursor.getColumnIndex( "ClassName" ) ) );
            userModel.setSchool_year_name( cursor.getString( cursor.getColumnIndex( "SchoolYearName" ) ) );
            userModel.setStart_year( cursor.getInt( cursor.getColumnIndex( "StartYear" ) ) );
            userModel.setEnd_year( cursor.getInt( cursor.getColumnIndex( "EndYear" ) ) );
            userModel.setSchool_year_id( cursor.getInt( cursor.getColumnIndex( "SchoolYearID" ) ) );
            slist.add( userModel );
        }
        cursor.close();
        return slist;
    }

    public List<TeacherModel> selectTeacherInfo() {
        String sQuery = "SELECT * FROM " + TABLE_TEACHERINFO;
        List<TeacherModel> slist = new ArrayList<>();
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery( sQuery, null );
        for (cursor.moveToFirst(); !cursor.isAfterLast(); cursor.moveToNext()) {
            TeacherModel userModel = new TeacherModel();
            userModel.setId( cursor.getString( cursor.getColumnIndex( "ID" ) ) );
            userModel.setName( cursor.getString( cursor.getColumnIndex( "Name" ) ) );
            userModel.setEmail( cursor.getString( cursor.getColumnIndex( "Email" ) ) );
            userModel.setBirth_date( cursor.getString( cursor.getColumnIndex( "BirthDate" ) ) );
            userModel.setWork_unit( cursor.getString( cursor.getColumnIndex( "WorkUnit" ) ) );
            userModel.setGraduating( cursor.getString( cursor.getColumnIndex( "Graduating" ) ) );
            userModel.setDiploma( cursor.getString( cursor.getColumnIndex( "Diploma" ) ) );
            userModel.setBank_account_number( cursor.getString( cursor.getColumnIndex( "BankAccountNumber" ) ) );
            userModel.setBank_id( cursor.getInt( cursor.getColumnIndex( "BankID" ) ) );
            userModel.setDescription( cursor.getString( cursor.getColumnIndex( "Description" ) ) );
            userModel.setRole( cursor.getInt( cursor.getColumnIndex( "Role" ) ) );
            slist.add( userModel );
        }
        cursor.close();
        return slist;
    }
}
