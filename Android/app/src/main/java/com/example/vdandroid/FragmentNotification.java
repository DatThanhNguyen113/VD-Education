package com.example.vdandroid;

import android.app.Activity;
import android.app.NotificationManager;
import android.media.RingtoneManager;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.app.NotificationCompat;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.Adapter.NotifyAdapter;
import com.example.vdandroid.Model.NotificationModel;
import com.example.vdandroid.Model.StudentModel;
import com.example.vdandroid.SQLite.SQLite;
import com.google.firebase.database.ChildEventListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class FragmentNotification extends Fragment {
    private ListView lvNotification;
    private NotificationModel model;
    public static List<NotificationModel> notificationList;
    private SQLite sqLite;
    private String MSSV = "", role_name = "";
    private List<StudentModel> listStudent;
    private NotifyAdapter adapter;
    int firtTime = 1;
    int childrenCount = 0;
    int i = 0;
    int maxID = 0;
    List<String> list_key;
    public Activity activity = (Activity) getActivity();
    List<NotificationModel> list;

    public FragmentNotification() {
         //activity = this.getActivity();
    }


    /**
     * Use this factory method to create a new instance of
     * this fragment
     *
     * @return A new instance of fragment FirstFragment.
     */
    public static FragmentNotification newInstance() {
        FragmentNotification fragment = new FragmentNotification();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate( savedInstanceState );
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate( R.layout.fragment_notification, container, false );
        onInit( view );
        sqLite = new SQLite( getActivity() );
        onGetNotification();
        return view;
    }

    private void onGetNotification() {
        final DatabaseReference myRef = FirebaseDatabase.getInstance().getReference( "Notification" );
        myRef.addValueEventListener( new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                try {
                    list = new ArrayList<>();
                    for(int i = notificationList.size() - 1; i < notificationList.size();i-- ){
                        if(i < 0){
                            break;
                        }else{
                            list.add( notificationList.get( i ) );
                        }
                    }
                    maxID = list.get( 0 ).getId();
                    for (int i = 0; i < list.size(); i++) {
                        if (maxID < list.get( i ).getId()) {
                            maxID = list.get( i ).getId();
                        }
                    }

                    if (firtTime == 1) {
                        if (list != null) {
                            if (list.size() > 0) {
                                adapter = new NotifyAdapter( getActivity(), R.layout.notification_item, list );
                                lvNotification.setAdapter( adapter );
                                adapter.notifyDataSetChanged();
                            }
                        }
                        firtTime = 2;
                        Log.e( "First_Time", "OK" );
                    }
                    listStudent = sqLite.selectStudentInfo();
                    MSSV = ((UserInfoBuffer) getActivity().getApplicationContext()).getID();
                    role_name = ((UserInfoBuffer) getActivity().getApplicationContext()).getRole_Name();
                    list_key = new ArrayList<>();

                    for (DataSnapshot dsp : dataSnapshot.getChildren()) {
                        if (role_name.equals( "STUDENT" )) {
                            model = dsp.getValue( NotificationModel.class );
                            if (model.getReceiver_name().equals( MSSV )) {
//                                for (int i = 0; i < list.size(); i++) {
                                    if (model.getId() > maxID) {
                                        //notificationList.add( model );
                                        list.add(0, model );
                                        adapter = new NotifyAdapter( getActivity(), R.layout.notification_item, list );
                                        lvNotification.setAdapter( adapter );
                                        adapter.notifyDataSetChanged();
                                    }
//                                }
                            } else {
                                if (model.getReceiver_name().equals( listStudent.get( 0 ).getClass_code() )) {
                                    if (model.getId() > maxID) {
                                        //notificationList.add( model );
                                        list.add(0, model );
                                        adapter = new NotifyAdapter( getActivity(), R.layout.notification_item, list );
                                        lvNotification.setAdapter( adapter );
                                        adapter.notifyDataSetChanged();
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

    private void onInit(View view) {
        lvNotification = view.findViewById( R.id.lvNotification );
    }

}
