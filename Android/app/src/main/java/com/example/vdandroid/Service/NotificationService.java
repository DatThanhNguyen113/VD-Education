package com.example.vdandroid.Service;

import android.app.NotificationManager;
import android.app.Service;
import android.content.Intent;
import android.media.RingtoneManager;
import android.os.IBinder;
import android.support.annotation.NonNull;
import android.support.v4.app.NotificationCompat;
import android.util.Log;

import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.Model.NotificationModel;
import com.example.vdandroid.Model.StudentModel;
import com.example.vdandroid.Model.TeacherModel;
import com.example.vdandroid.R;
import com.example.vdandroid.SQLite.SQLite;
import com.google.firebase.database.ChildEventListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.List;

import static com.example.vdandroid.FragmentNotification.notificationList;

public class NotificationService extends Service {
    private FirebaseDatabase database = FirebaseDatabase.getInstance();
    //    private DatabaseReference myRef = database.getReference().child("Notification");
    private final DatabaseReference myRef = FirebaseDatabase.getInstance().getReference( "Notification" );
    private NotificationModel model;
    List<StudentModel> listStudent;
    List<TeacherModel> listTeacher;
    SQLite sqLite;
    int firstTime = 1;
    int maxID = 0;


    public NotificationService() {
    }

    @Override
    public IBinder onBind(Intent intent) {
        // TODO: Return the communication channel to the service.
        return null;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        sqLite = new SQLite( NotificationService.this );
        myRef.addChildEventListener( new ChildEventListener() {
            @Override
            public void onChildAdded(DataSnapshot dataSnapshot, String s) {
                try {
                    maxID = notificationList.get( 0 ).getId();
                    for (int i = 0; i < notificationList.size(); i++) {
                        if (maxID < notificationList.get( i ).getId()) {
                            maxID = notificationList.get( i ).getId();
                        }
                    }
                    listStudent = sqLite.selectStudentInfo();
                    final String role_name = ((UserInfoBuffer) getApplicationContext()).getRole_Name();
                    final String MSSV = ((UserInfoBuffer) getApplicationContext()).getID();
                    //for (DataSnapshot dsp : dataSnapshot.getChildren()) {
                        if (role_name.equals( "STUDENT" )) {
                            model = dataSnapshot.getValue( NotificationModel.class );
                            if (model.getReceiver_name().equals( MSSV )) {
                                if (model.getId() > maxID) {
                                    NotificationCompat.Builder mBuilder =
                                            (NotificationCompat.Builder) new NotificationCompat.Builder( getApplicationContext() )
                                                    .setSmallIcon( R.drawable.logo )
                                                    .setContentTitle( model.getSubject() )
                                                    .setVibrate( new long[]{500, 500} ).setSound( RingtoneManager.getDefaultUri( RingtoneManager.TYPE_NOTIFICATION ) )
                                                    .setContentText( model.getBody() );

                                    NotificationManager mNotifyMgr =
                                            (NotificationManager) getSystemService( NOTIFICATION_SERVICE );
                                    mNotifyMgr.notify( 001, mBuilder.build() );
//                                    break;
                                }
                            } else {
                                if (model.getReceiver_name().equals( listStudent.get( 0 ).getClass_code() )) {
                                    if (model.getId() > maxID) {
                                        NotificationCompat.Builder mBuilder =
                                                (NotificationCompat.Builder) new NotificationCompat.Builder( getApplicationContext() )
                                                        .setSmallIcon( R.drawable.logo )
                                                        .setContentTitle( model.getSubject() )
                                                        .setVibrate( new long[]{500, 500} ).setSound( RingtoneManager.getDefaultUri( RingtoneManager.TYPE_NOTIFICATION ) )
                                                        .setContentText( model.getBody() );

                                        NotificationManager mNotifyMgr =
                                                (NotificationManager) getSystemService( NOTIFICATION_SERVICE );
                                        mNotifyMgr.notify( 001, mBuilder.build() );
//                                        break;
                                    }
                                }
                            }
//                        }
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
//                try{
//                    if (firstTime == 1){
//                        firstTime = 2;
//                        Log.d( "FirstTIME_SERVICE", "OK" );
//                    }else{
//                        int i = (int) dataSnapshot.getChildrenCount();
//                        Log.d( "Count_Item", String.valueOf( i ) );
//                        model = dataSnapshot.getValue( NotificationModel.class );
//
//
//                        listStudent = sqLite.selectStudentInfo();
//                        if (model.getReceiver_name().equals( MSSV )) {
//                            NotificationCompat.Builder mBuilder =
//                                    (NotificationCompat.Builder) new NotificationCompat.Builder( getApplicationContext() )
//                                            .setSmallIcon( R.drawable.logo )
//                                            .setContentTitle( model.getSubject() )
//                                            .setVibrate( new long[]{500, 500} ).setSound( RingtoneManager.getDefaultUri( RingtoneManager.TYPE_NOTIFICATION ) )
//                                            .setContentText( model.getBody() );
//
//                            NotificationManager mNotifyMgr =
//                                    (NotificationManager) getSystemService( NOTIFICATION_SERVICE );
//                            mNotifyMgr.notify( 001, mBuilder.build() );
//                        } else {
//                            if (model.getReceiver_name().equals( listStudent.get( 0 ).getClass_code() )) {
//                                NotificationCompat.Builder mBuilder =
//                                        (NotificationCompat.Builder) new NotificationCompat.Builder( getApplicationContext() )
//                                                .setSmallIcon( R.drawable.logo )
//                                                .setContentTitle( model.getSubject() )
//                                                .setVibrate( new long[]{500, 500} ).setSound( RingtoneManager.getDefaultUri( RingtoneManager.TYPE_NOTIFICATION ) )
//                                                .setContentText( model.getBody() );
//
//                                NotificationManager mNotifyMgr =
//                                        (NotificationManager) getSystemService( NOTIFICATION_SERVICE );
//                                mNotifyMgr.notify( 001, mBuilder.build() );
//                            }
//                        }
//                        Log.d( "SecondTIME_SERVICE", "OK" );
//                    }
//                }catch (Exception ex){
//                    ex.printStackTrace();
//                }
            }

            @Override
            public void onChildChanged(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onChildRemoved(DataSnapshot dataSnapshot) {

            }

            @Override
            public void onChildMoved(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onCancelled(DatabaseError databaseError) {

            }
        } );
//        onGetNotification();

    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {

        //Toast.makeText(getApplicationContext(), "Service started", Toast.LENGTH_LONG).show();

        return START_STICKY;
    }


    private void onGetNotification() {
        final DatabaseReference myRef = FirebaseDatabase.getInstance().getReference( "Notification" );
        myRef.addValueEventListener( new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                try {
                    maxID = notificationList.get( 0 ).getId();
                    for (int i = 0; i < notificationList.size(); i++) {
                        if (maxID < notificationList.get( i ).getId()) {
                            maxID = notificationList.get( i ).getId();
                        }
                    }
                    listStudent = sqLite.selectStudentInfo();
                    final String role_name = ((UserInfoBuffer) getApplicationContext()).getRole_Name();
                    final String MSSV = ((UserInfoBuffer) getApplicationContext()).getID();
                    for (DataSnapshot dsp : dataSnapshot.getChildren()) {
                        if (role_name.equals( "STUDENT" )) {
                            model = dsp.getValue( NotificationModel.class );
                            if (model.getReceiver_name().equals( MSSV )) {
                                if (model.getId() > maxID) {
                                    NotificationCompat.Builder mBuilder =
                                            (NotificationCompat.Builder) new NotificationCompat.Builder( getApplicationContext() )
                                                    .setSmallIcon( R.drawable.logo )
                                                    .setContentTitle( model.getSubject() )
                                                    .setVibrate( new long[]{500, 500} ).setSound( RingtoneManager.getDefaultUri( RingtoneManager.TYPE_NOTIFICATION ) )
                                                    .setContentText( model.getBody() );

                                    NotificationManager mNotifyMgr =
                                            (NotificationManager) getSystemService( NOTIFICATION_SERVICE );
                                    mNotifyMgr.notify( 001, mBuilder.build() );
                                    break;
                                }
                            } else {
                                if (model.getReceiver_name().equals( listStudent.get( 0 ).getClass_code() )) {
                                    if (model.getId() > maxID) {
                                        NotificationCompat.Builder mBuilder =
                                                (NotificationCompat.Builder) new NotificationCompat.Builder( getApplicationContext() )
                                                        .setSmallIcon( R.drawable.logo )
                                                        .setContentTitle( model.getSubject() )
                                                        .setVibrate( new long[]{500, 500} ).setSound( RingtoneManager.getDefaultUri( RingtoneManager.TYPE_NOTIFICATION ) )
                                                        .setContentText( model.getBody() );

                                        NotificationManager mNotifyMgr =
                                                (NotificationManager) getSystemService( NOTIFICATION_SERVICE );
                                        mNotifyMgr.notify( 001, mBuilder.build() );
                                        break;
                                    }
                                }
                            }
                        }
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        } );
    }


}